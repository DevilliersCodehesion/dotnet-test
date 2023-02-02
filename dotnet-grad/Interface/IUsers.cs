using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_grad.Models;

namespace dotnet_grad.Interface
{
  public interface IUsers
  {
    public Task<List<UserModel>> GetUsersDetails();
    public Task<UserModel> GetUserDetails(int id);
    public Task<UserModel> UpdateUser(UserModel user);
    public Task<UserModel> AddUser(UserModel user);
    public Task<UserModel> DeleteUser(int id);
    public bool CheckUser(int id);
  }
}