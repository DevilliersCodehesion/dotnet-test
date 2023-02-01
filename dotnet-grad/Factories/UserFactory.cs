using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_grad.Models;

namespace dotnet_grad.Factories
{
  public class UserFactory
  {
    public static UserModel create(string name, string surname, string id_number, string full_name, string email, string username)
    {
      return new UserModel(name, surname, id_number, full_name, email, username);
    }
  }
}