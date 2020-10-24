using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    private readonly string creatorSql = @"SELECT 
    vault.*,
    profile.* 
    FROM vaults vault 
    JOIN profiles profile on vault.creatorId = profile.id ";

    internal int Create(Vault newVault)
    {

      string sql = @"
INSERT INTO vaults
(creatorId, name, description, isPrivate)
VALUES
(@CreatorId, @Name, @Description, @isPrivate);
SELECT LAST_INSERT_ID();
"; return _db.ExecuteScalar<int>(sql, newVault);

    }

    internal IEnumerable<Vault> GetAll()
    {
      string sql = creatorSql;
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
      {
        vault.Creator = profile; return vault;
      }, splitOn: "id");
    }

    internal Vault GetById(int id)
    {
      string sql = creatorSql + "WHERE vault.id = @id";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
      {
        vault.Creator = profile; return vault;
      }, new { id }, splitOn: "id").FirstOrDefault();

    }

    internal IEnumerable<Vault> GetByCreatorId(string creatorId)
    {
      string sql = creatorSql + "WHERE creatorId = @creatorId;";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
      { vault.Creator = profile; return vault; },
      new { creatorId }, splitOn: "id");
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}