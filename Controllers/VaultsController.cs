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
    public async Task<ActionResult<IEnumerable<Vault>>> GetAll()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.GetAll(userInfo?.Id));
      }
      catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Vault>>> GetById(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.GetById(id, userInfo?.Id));
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
    public async Task<ActionResult<IEnumerable<VaultKeepViewModel>>> GetKeepsByVaultId(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_keepsService.GetKeepsByVaultId(id, userInfo?.Id));
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