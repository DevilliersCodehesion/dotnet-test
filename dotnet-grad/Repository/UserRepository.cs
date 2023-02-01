using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_grad.Interface;
using dotnet_grad.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_grad.Repository
{
  public class UserRepository : IUsers
  {
    readonly TestContext _testContext = new();

    public UserRepository(TestContext testContext)
    {
      _testContext = testContext;
    }

    public async Task<List<UserModel>> GetUsersDetails()
    {
      return await _testContext.Users.ToListAsync(cancellationToken: CancellationToken.None);
    }

    public async Task<UserModel> GetUserDetails(int id)
    {
      UserModel? user = await _testContext.Users.FindAsync(id);
      if (user != null)
      {
        return user;
      }
      else
      {
        throw new ArgumentNullException();
      }
    }

    public async Task<UserModel> AddUser(UserModel user)
    {
      await _testContext.Users.AddAsync(user);
      await _testContext.SaveChangesAsync();
      UserModel createdUser = await _testContext.Users.FindAsync(user.id);
      return createdUser;
    }

    public async Task<UserModel> UpdateUser(UserModel user)
    {
      _testContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      await _testContext.SaveChangesAsync();
      UserModel returnedUser = await _testContext.Users.FindAsync(user.id);
      return returnedUser;
    }

    public async Task<UserModel> DeleteUser(int id)
    {

      UserModel? user = await _testContext.Users.FindAsync(id);

      if (user != null)
      {
        _testContext.Users.Remove(user);
        _testContext.SaveChanges();
        return user;
      }
      else
      {
        throw new ArgumentNullException();
      }

    }

    public bool CheckUser(int id)
    {
      return _testContext.Users.Any(e => e.id == id);
    }
  }
}