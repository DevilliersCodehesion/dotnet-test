using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_grad.Models;

namespace dotnet_grad.Interface
{
  public interface IToken
  {
    public Task<UserInfo> getUserToken(string email, string password);
    public Task<List<UserInfo>> getUserInfo();
    public Task<UserInfo> addUserInfo(UserInfo userInfo);

  }
}