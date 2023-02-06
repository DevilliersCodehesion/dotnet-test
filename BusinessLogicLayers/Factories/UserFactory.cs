using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayers.Factories
{
  public class UserFactory
  {
    public static User create(string name, string surname, string id_number, string full_name, string email, string username)
    {
      return new User(name, surname, id_number, full_name, email, username);
    }
  }
}