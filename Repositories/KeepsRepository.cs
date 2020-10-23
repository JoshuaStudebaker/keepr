using System.Data;
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

    internal int Create(Keep keep)
    {
      string sql = @"
INSERT INTO keeps
(creatorId, name, description, img)
VALUES
(@CreatorId, @Name, @Description, @Img)
";
      return
    }
  }
}