using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;
    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }
    internal Profile GetOrCreateProfile(Profile userInfo)
    {
      Profile profile = _repo.GetById(userInfo.Id);
      if (profile == null)
      {
        return _repo.Create(userInfo);
      }
      return profile;
    }
    internal Profile GetById(string id)
    {
      Profile activeProfile = _repo.GetById(id);
      if (activeProfile == null)
      { throw new Exception("Invalid Id / No Longer exists"); }

      return activeProfile;
    }
  }
}