using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using dotnet_grad.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_grad.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    TestContext testContext;
    public UserController(TestContext _testContext)
    {
      testContext = _testContext;
    }

    [HttpGet("GetAllUsers")]
    public List<UserModel> getUsers()
    {
      return testContext.Users.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<UserModel> getUser(int id)
    {
      try
      {
        UserModel user = testContext.Users.Find(id);
        return Ok(user);
      }
      catch (Exception e)
      {
        return NotFound("user not found");
      }
    }

    [HttpPost("createUser")]
    public async Task<ActionResult<UserModel>> createUser(UserModel userModel)
    {
      testContext.Add(userModel);
      await testContext.SaveChangesAsync();
      return CreatedAtAction("GetUser", new { id = userModel.id }, userModel);
    }
  }
}