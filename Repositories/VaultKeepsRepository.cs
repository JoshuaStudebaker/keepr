using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(VaultKeep newVaultKeep)
    {
      string sql = @"
        INSERT INTO vaultkeeps
        (creatorId, keepId, vaultId)
        VALUES
        (@CreatorId, @KeepId, @VaultId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVaultKeep);
    }
  }
}