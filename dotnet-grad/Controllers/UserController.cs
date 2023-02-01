using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using dotnet_grad.Dtos.Request;
using dotnet_grad.Dtos.Response;
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
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> getUsers()
    {
      List<UserModel> users = await _IUser.GetUsersDetails();
      IEnumerable<UserResponseDto> dto = users.Select(x => new UserResponseDto(x.name, x.surname, x.full_name, x.email));
      return Ok(dto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponseDto>> getUser(int id)
    {
      UserModel user = await _IUser.GetUserDetails(id);
      if (user == null)
      {
        return NotFound();
      }
      return Ok(new UserResponseDto(user.name, user.surname, user.full_name, user.email));
    }

    [HttpPost]
    public async Task<ActionResult<UserModel>> createUser([FromBody] UserRequestDto user)
    {
      UserModel userModel = new UserModel(user.Name, user.Surname, user.IdNumber, user.FullName, user.Email, user.Username);
      UserModel createdUser = await _IUser.AddUser(userModel);
      return Ok(new UserResponseDto(createdUser.name, createdUser.surname, createdUser.full_name, createdUser.email));
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<UserModel>> updateUser(int id, [FromBody] UserRequestDto user)
    {
      UserModel userModel = new UserModel(user.Name, user.Surname, user.IdNumber, user.FullName, user.Email, user.Username);
      userModel.id = id;
      try
      {
        UserModel updatedUser = await _IUser.UpdateUser(userModel);
        return Ok(new UserResponseDto(updatedUser.name, updatedUser.surname, updatedUser.full_name, updatedUser.email));
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