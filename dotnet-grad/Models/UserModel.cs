using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_grad.Models
{
  public class UserModel
  {
    public UserModel(string name, string surname, int id_number, string full_name, string email, string username)
    {
      this.name = name;
      this.surname = surname;
      this.id_number = id_number;
      this.full_name = full_name;
      this.email = email;
      this.username = username;
    }

    [Key] public int id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public int id_number { get; set; }
    public string full_name { get; set; }
    public string email { get; set; }
    public string username { get; set; }

    public List<OrganisationModel> organsiation_models;
  }
}

