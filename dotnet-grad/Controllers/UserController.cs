using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using dotnet_grad.Interface;
using dotnet_grad.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_grad.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    TestContext testContext;
    private readonly IUsers _IUser;
    public UserController(TestContext _testContext, IUsers Iuser)
    {
      testContext = _testContext;
      _IUser = Iuser;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserModel>>> getUsers()
    {
      return await _IUser.GetUsersDetails();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserModel>> getUser(int id)
    {
      var user = await _IUser.GetUserDetails(id);
      if (user == null)
      {
        return NotFound();
      }
      return user;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<UserModel>> createUser([FromBody] UserModel user)
    {
      UserModel createdUser = await _IUser.AddUser(user);
      return createdUser;
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<UserModel>> updateUser(int id, [FromBody] UserModel user)
    {
      if (id != user.id)
      {
        return BadRequest();
      }
      try
      {
        UserModel updatedUser = await _IUser.UpdateUser(user);
        return updatedUser;
      }
      catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
      {
        if (_IUser.CheckUser(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
    }

  }
}