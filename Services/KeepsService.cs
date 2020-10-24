using System;
using System.Collections.Generic;
using System.Linq;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }

    // 
    internal Keep Create(Keep newKeep)
    {
      newKeep.Id = _repo.Create(newKeep);
      return newKeep;
    }

    internal IEnumerable<Keep> GetAll()
    {
      IEnumerable<Keep> keeps = _repo.GetAll();
      return keeps.ToList();
    }

    internal Keep GetById(int id)
    {
      Keep activeKeep = _repo.GetById(id);
      if (activeKeep == null)
      { throw new Exception("Invalid Id / No Longer exists"); }

      return activeKeep;
    }

    internal IEnumerable<Keep> GetByCreatorId(string creatorId)
    {
      return _repo.GetByCreatorId(creatorId).ToList();
    }

    internal object Delete(int id, string userId)
    {
      Keep activeKeep = _repo.GetById(id);
      if (activeKeep == null)
      { throw new Exception("Invalid Id / No longer exists"); }
      if (activeKeep.CreatorId != userId)
      { throw new Exception("Access denied; Only creators can delete their own keep"); }
      _repo.Delete(id);
      return "Deleted successfully";

    }

  }

}