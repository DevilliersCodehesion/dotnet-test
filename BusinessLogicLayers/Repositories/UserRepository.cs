using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayers.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayers.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly DatabaseContext _databaseContext;
    public UserRepository(DatabaseContext databaseContext)
    {
      _databaseContext = databaseContext;
    }

    public async Task<User> AddUser(User user)
    {
      await _databaseContext.Users.AddAsync(user);
      await _databaseContext.SaveChangesAsync();
      User createdUser = await _databaseContext.Users.FindAsync(user.Id);
      return createdUser;
    }

    public bool CheckUser(int id)
    {
      return _databaseContext.Users.Any(e => e.Id == id);
    }

    public async Task<User> DeleteUser(int id)
    {
      User? user = await _databaseContext.Users.FindAsync(id);

      if (user != null)
      {
        _databaseContext.Users.Remove(user);
        _databaseContext.SaveChanges();
        return user;
      }
      else
      {
        throw new ArgumentNullException();
      }
    }

    public async Task<User> GetUserDetails(int id)
    {
      User? user = await _databaseContext.Users.FindAsync(id);
      if (user != null)
      {
        return user;
      }
      else
      {
        throw new ArgumentNullException();
      }
    }

    public async Task<List<User>> GetUsersDetails()
    {
      return await _databaseContext.Users.ToListAsync(cancellationToken: CancellationToken.None);
    }

    public async Task<User> UpdateUser(int id, User user)
    {
      _databaseContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      await _databaseContext.SaveChangesAsync();
      User returnedUser = await _databaseContext.Users.FindAsync(id);
      return returnedUser;
    }
  }
}