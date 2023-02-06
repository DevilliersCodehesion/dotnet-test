using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
  public class User
  {
    public User()
    {

    }
    public User(string name, string surname, string id_number, string full_name, string email, string username)
    {
      this.Name = name;
      this.Surname = surname;
      this.IdNumber = id_number;
      this.Fullname = full_name;
      this.Email = email;
      this.Username = username;
    }

    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string IdNumber { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }

    public List<Organisation>? Organisations;
  }
}