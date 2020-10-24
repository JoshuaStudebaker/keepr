using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
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
  }
}