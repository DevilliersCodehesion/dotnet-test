using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayers.Interfaces
{
  public interface ITokenRepository
  {
    public Task<UserInfo> getUserToken(string email, string password);
    public Task<List<UserInfo>> getUserInfo();
    public Task<UserInfo> addUserInfo(UserInfo userInfo);
  }
}