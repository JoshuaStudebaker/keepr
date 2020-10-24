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
    private readonly ProfilesService _ps;

    private readonly KeepsService _keepsService;

    public ProfilesController(ProfilesService ps, KeepsService ks)
    {
      _ps = ps;
      _keepsService = ks;
    }


    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/keeps")]
    [Authorize]
    public ActionResult<Profile> GetByCreatorId(string id)
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

  }
}