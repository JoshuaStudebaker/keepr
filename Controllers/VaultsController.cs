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
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _service;
    private readonly KeepsService _keepsService;
    public VaultsController(VaultsService service, KeepsService keepsService)
    {
      _service = service;
      _keepsService = keepsService;
    }

    [HttpGet]
    // REVIEW maybe need async task action 
    public ActionResult<IEnumerable<Vault>> GetAll()
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
    public ActionResult<IEnumerable<Vault>> GetById(int id)
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
    public async Task<ActionResult<Vault>> Create([FromBody] Vault newVaultBody)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newVaultBody.CreatorId = userInfo.Id;
        Vault newVault = _service.Create(newVaultBody);
        newVault.Creator = userInfo;
        return Ok(newVault);
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
    [HttpGet("{id}/keeps")]
    public ActionResult<IEnumerable<VaultKeepViewModel>> GetKeeps(int id)
    {
      try
      {
        return Ok(_keepsService.GetKeepsByVaultId(id));
      }
      catch (AccessViolationException e)
      {
        return Forbid(e.Message);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}