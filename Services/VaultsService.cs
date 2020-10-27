using System;
using System.Collections.Generic;
using System.Linq;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    // 
    internal Vault Create(Vault newVault)
    {
      newVault.Id = _repo.Create(newVault);
      return newVault;
    }

    internal IEnumerable<Vault> GetAll(string userId)
    {
      IEnumerable<Vault> vaults = _repo.GetAll();
      return vaults.ToList().FindAll(v => v.CreatorId == userId || v.IsPrivate == false);
    }

    internal IEnumerable<Vault> GetByCreatorId(string creatorId, string userId)
    {
      IEnumerable<Vault> vaults = _repo.GetByCreatorId(creatorId).ToList();
      return vaults.ToList().FindAll(v => v.CreatorId == userId || v.IsPrivate == false);
    }
    internal Vault GetById(int id, string userId)
    {
      Vault activeVault = _repo.GetById(id);
      if (activeVault == null)
      { throw new Exception("Invalid Id / No Longer exists"); }
      if (activeVault.IsPrivate == true && userId != activeVault.CreatorId)
      {
        throw new Exception("Access Denied!");
      }

      return activeVault;
    }


    internal object Delete(int id, string userId)
    {
      Vault activeVault = _repo.GetById(id);
      if (activeVault == null)
      { throw new Exception("Invalid Id / No longer exists"); }
      if (activeVault.CreatorId != userId)
      { throw new Exception("Access denied; Only creators can delete their own vault"); }
      _repo.Delete(id);
      return "Deleted successfully";

    }

  }

}