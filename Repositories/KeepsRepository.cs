using System.Data;
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
  }
}