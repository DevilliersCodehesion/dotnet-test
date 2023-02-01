using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_grad.Dtos.Response;
using dotnet_grad.Interface;
using dotnet_grad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_grad.Repository
{
  public class TokenRepository : IToken
  {
    TestContext _testContext;

    public TokenRepository(TestContext testContext)
    {
      _testContext = testContext;
    }

    public async Task<UserInfo> getUserToken(string email, string password)
    {
      return await _testContext.UserInfo.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }


    public async Task<List<UserInfo>> getUserInfo()
    {
      return await _testContext.UserInfo.ToListAsync(cancellationToken: CancellationToken.None);
    }

    public async Task<UserInfo> addUserInfo(UserInfo userInfo)
    {
      await _testContext.UserInfo.AddAsync(userInfo);
      await _testContext.SaveChangesAsync();
      UserInfo createdUser = await _testContext.UserInfo.FindAsync(userInfo.Id);
      return createdUser;
    }
  }
}