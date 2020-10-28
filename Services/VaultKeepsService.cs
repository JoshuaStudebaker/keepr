using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;

    private readonly VaultsService _vaultsService;
    public VaultKeepsService(VaultKeepsRepository repo, VaultsService vaultsService)
    {
      _repo = repo;
      _vaultsService = vaultsService;
    }

    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
      Vault vaultCheck = _vaultsService.GetById(newVaultKeep.VaultId, newVaultKeep.CreatorId);
      if (vaultCheck.CreatorId == newVaultKeep.CreatorId)
      {
        int id = _repo.Create(newVaultKeep);
        newVaultKeep.Id = id;
        return newVaultKeep;
      }
      else
      {
        throw new Exception("Invalid");
      }
    }

    internal void Delete(int id, string userId)
    {
      var vk = _repo.GetById(id);
      if (vk == null)
      {
        throw new Exception("Invalid Id");
      }
      if (vk.CreatorId != userId)
      {
        throw new Exception("Access Denied");
      }
      _repo.Delete(id);
    }
  }
}