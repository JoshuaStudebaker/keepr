using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;

    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    public VaultKeep Create(VaultKeep newVaultKeep)
    {
      int id = _repo.Create(newVaultKeep);
      newVaultKeep.Id = id;
      return newVaultKeep;
    }

    internal void Delete(int id)
    {
      var vk = _repo.GetById(id);
      if (vk == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
    }
  }
}