using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using dotnet_grad.Dtos.Request;
using dotnet_grad.Dtos.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resources.Commands;
using Resources.Queries;

namespace dotnet_grad.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    DatabaseContext testContext;
    private readonly IMediator _mediator;
    public UserController(DatabaseContext _testContext, IMediator mediator)
    {
      testContext = _testContext;
      _mediator = mediator;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> getUsers()
    {
      var query = new GetAllUsersQuery();
      var response = await _mediator.Send(query);
      return Ok(response);
    }
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponseDto>> getUser(int id)
    {
      var query = new GetUserByIdQuery(id);
      var response = await _mediator.Send(query);
      if (response == null)
      {
        return NotFound();
      }
      return Ok(response);
    }

    [Authorize(Policy = "admin")]
    [HttpPost]
    public async Task<ActionResult<UserResponseDto>> createUser([FromBody] UserRequestDto user)
    {
      // if (!ModelState.IsValid)
      // {
      var command = new CreateUserCommand(user);
      var response = await _mediator.Send(command);
      return Ok(response);
      // }

    }

    [Authorize(Policy = "admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult<UserResponseDto>> updateUser(int id, [FromBody] UserRequestDto user)
    {
      if (!ModelState.IsValid)
      {
        var command = new UpdateUserCommand(id, user);
        var response = await _mediator.Send(command);
        try
        {
          return Ok(response);
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
        {
          return NotFound();
        }
      }
      return BadRequest();
    }
  }

}
