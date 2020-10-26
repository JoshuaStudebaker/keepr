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
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _service;

    public KeepsController(KeepsService service)
    {
      _service = service;
    }

    [HttpGet]
    // REVIEW maybe need async task action 
    public ActionResult<IEnumerable<Keep>> GetAll()
    {
      try
      {
        return Ok(_service.GetAll());
      }
      catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Keep>> GetById(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Keep>> Create([FromBody] Keep newKeepBody)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newKeepBody.CreatorId = userInfo.Id;
        Keep newKeep = _service.Create(newKeepBody);
        newKeep.Creator = userInfo;
        return Ok(newKeep);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPatch("{id}")]
    public ActionResult<Keep> Patch(int id, [FromBody] KeepPatch keepPatchBody)
    {
      try
      {
        keepPatchBody.Id = id;
        Keep updatedKeep = _service.Patch(keepPatchBody);        
        return Ok(updatedKeep);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.Delete(id, userInfo.Id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);

      }
    }

  }
}