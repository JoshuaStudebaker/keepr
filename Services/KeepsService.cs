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

    internal Keep Patch(KeepPatch keepPatch)
    {
      Keep keep = _repo.GetById(keepPatch.Id);
      if (keep == null) { throw new Exception("Invalid Id / No longer exists"); }
      keep.Views = keepPatch.Views;
      keep.Keeps = keepPatch.Keeps;
      Keep updatedKeep = _repo.Update(keep);
      return _repo.GetById(updatedKeep.Id);
    }


    internal IEnumerable<Keep> GetByCreatorId(string creatorId)
    {
      return _repo.GetByCreatorId(creatorId).ToList();
    }

    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
    {
      Vault vaultOfKeeps = _vaultsRepository.GetById(vaultId);
      if (vaultOfKeeps == null) { throw new Exception("invalid Id / No longer exists"); }
      if (vaultOfKeeps.CreatorId != userId && vaultOfKeeps.IsPrivate == true)
      {
        throw new Exception("Access Denied");
      }

      // NOTE the original way I solved it, before realizing I had to to move the vk.id = vaultKeepId up above above profile (without the FROM statememt)
      // List<VaultKeepViewModel> noCreator = _repo.getKeepsByVaultId(vaultId).ToList();
      // List<VaultKeepViewModel> noVaultKeepId = _repo.getKeeps2ByVaultId(vaultId).ToList();

      // for (int i = 0; i < noCreator.Count(); i++)
      // {
      //   noCreator[i].Creator = noVaultKeepId[i].Creator;
      // }
      // IEnumerable<VaultKeepViewModel> full = noCreator.AsEnumerable();
      //  IEnumerable<Keep> full
      // return full;


      return _repo.getKeeps2ByVaultId(vaultId);
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