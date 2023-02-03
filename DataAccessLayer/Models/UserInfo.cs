using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
  public class UserInfo
  {
    public UserInfo(string email, string password, string role)
    {
      Email = email;
      Password = password;
      Role = role;
    }

    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }

  }
}