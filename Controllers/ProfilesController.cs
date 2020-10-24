using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _profilesService;

    private readonly KeepsService _keepsService;

    private readonly VaultsService _vaultsService;

    public ProfilesController(ProfilesService ps, KeepsService ks, VaultsService vs)
    {
      _profilesService = ps;
      _keepsService = ks;
      _vaultsService = vs;
    }


    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_profilesService.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/keeps")]
    public ActionResult<Profile> GetKeepsByCreatorId(string id)
    {
      try
      {

        return Ok(_keepsService.GetByCreatorId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/vaults")]
    public ActionResult<Profile> GetVaultsByCreatorId(string id)
    {
      try
      {

        return Ok(_vaultsService.GetByCreatorId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}