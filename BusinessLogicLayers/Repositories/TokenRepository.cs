using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayers.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayers.Repositories
{
  public class TokenRepository : ITokenRepository
  {
    private readonly DatabaseContext _databseContext;
    public TokenRepository(DatabaseContext databaseContext)
    {
      _databseContext = databaseContext;
    }

    public async Task<UserInfo> addUserInfo(UserInfo userInfo)
    {
      await _databseContext.UserInfo.AddAsync(userInfo);
      await _databseContext.SaveChangesAsync();
      UserInfo createdUser = await _databseContext.UserInfo.FindAsync(userInfo.Id);
      return createdUser;
    }

    public async Task<List<UserInfo>> getUserInfo()
    {
      return await _databseContext.UserInfo.ToListAsync(cancellationToken: CancellationToken.None);
    }

    public async Task<UserInfo> getUserToken(string email, string password)
    {
      return await _databseContext.UserInfo.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }
  }
}