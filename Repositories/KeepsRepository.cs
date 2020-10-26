using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    private readonly string creatorSql = @"SELECT 
    keep.*,
    profile.* 
    FROM keeps keep 
    JOIN profiles profile on keep.creatorId = profile.id ";

    // This is sending back the Id, because of the 'Select Last_Insert_ID()
    // The other way to do this is to set newKeep.Id this created Id here, but instead this is done in the service (I believe this is being done right)
    // REVIEW For some reason, this is not working for the image and descriptions in making them to their default
    internal int Create(Keep newKeep)
    {
      if (newKeep.Img != null && newKeep.Description != null)
      {
        string sql = @"
INSERT INTO keeps
(creatorId, name, description, img)
VALUES
(@CreatorId, @Name, @Description, @Img);
SELECT LAST_INSERT_ID();
"; return _db.ExecuteScalar<int>(sql, newKeep);
      }
      else if (newKeep.Description != null)
      {
        string sql = @"
INSERT INTO keeps
(creatorId, name, description)
VALUES
(@CreatorId, @Name, @Description);
SELECT LAST_INSERT_ID();
"; return _db.ExecuteScalar<int>(sql, newKeep);
      }
      else
      {
        string sql = @"
INSERT INTO keeps
(creatorId, name, img)
VALUES
(@CreatorId, @Name, @Img);
SELECT LAST_INSERT_ID();
";
        return _db.ExecuteScalar<int>(sql, newKeep);
      }

    }



    internal IEnumerable<Keep> GetAll()
    {
      string sql = creatorSql;
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
      {
        keep.Creator = profile; return keep;
      }, splitOn: "id");
    }

    internal Keep GetById(int id)
    {
      string sql = creatorSql + "WHERE keep.id = @id";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
      {
        keep.Creator = profile; return keep;
      }, new { id }, splitOn: "id").FirstOrDefault();

    }
    // private readonly string creatorSql = @"SELECT 
    //     keep.*,
    //     profile.* 
    //     FROM keeps keep 
    //     JOIN profiles profile on keep.creatorId = profile.id ";
    //  return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
    //       {
    //         keep.Creator = profile; return keep;
    //       }, splitOn: "id")
    internal IEnumerable<Keep> getKeepsByVaultId(int vaultId)
    {
      string sql = @"
      SELECT keep.*,
      profile.*,
      vaultKeep.id as VaultKeepId
      FROM vaultkeeps vaultKeep
      LEFT JOIN keeps keep on keep.id = vaultKeep.keepId
      INNER JOIN profiles profile on keep.creatorId = profile.id
      WHERE vaultId = @vaultId
      ";

      return _db.Query<VaultKeepViewModel, Profile, VaultKeepViewModel>(sql, (vaultKeepViewModel, profile) =>
      {
        vaultKeepViewModel.Creator = profile; return vaultKeepViewModel;
      }, new { vaultId }, splitOn: "id");
    }

    // REVIEW THINK ABOUT HOW TO DO EDIT
     internal Keep Update(Keep updatedKeep)
    {
        string sql = @"
            UPDATE keeps
            SET
            creatorId = @CreatorId,
            name = @Name,
            description = @Description,
            img = @Img,
            views = @Views,
            shares = @Shares,
            keeps = @Keeps
            WHERE id = @Id;";
            _db.Execute(sql, updatedKeep);
            return updatedKeep;
    }


    internal IEnumerable<Keep> GetByCreatorId(string creatorId)
    {
      string sql = creatorSql + "WHERE creatorId = @creatorId;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
      { keep.Creator = profile; return keep; },
      new { creatorId }, splitOn: "id");
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}