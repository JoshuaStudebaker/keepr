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
    private readonly VaultsRepository _vaultsRepository;

    public KeepsService(KeepsRepository repo, VaultsRepository vaultsRepository)
    {
      _repo = repo;
      _vaultsRepository = vaultsRepository;
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

    internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId)
    {
      Vault vaultOfKeeps = _vaultsRepository.GetById(vaultId);
      if (vaultOfKeeps == null) { throw new Exception("invalid Id / No longer exists"); }
      return _repo.getKeepsByVaultId(vaultId);
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