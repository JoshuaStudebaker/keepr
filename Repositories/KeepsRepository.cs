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

    internal int Create(Keep newKeep)
    {
      string sql = @"
INSERT INTO keeps
(creatorId, name, description, img)
VALUES
(@CreatorId, @Name, @Description, @Img);
SELECT LAST_INSERT_ID();
";
      return _db.ExecuteScalar<int>(sql, newKeep);
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

    // REVIEW THANK ABOUT HOW TO DO EDIT

    internal IEnumerable<Keep> GetByCreatorId(string profileId)
    {
      string sql = creatorSql + "WHERE creatorId = @profileId;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { profileId }, splitOn: "id");
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM blogs WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}