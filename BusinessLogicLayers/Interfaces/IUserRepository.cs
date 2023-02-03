using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayers.Interfaces
{
  public interface IUserRepository
  {
    public Task<List<User>> GetUsersDetails();
    public Task<User> GetUserDetails(int id);
    public Task<User> UpdateUser(int id, User user);
    public Task<User> AddUser(User user);
    public Task<User> DeleteUser(int id);
    public bool CheckUser(int id);
  }
}