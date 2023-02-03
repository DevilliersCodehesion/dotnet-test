using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
  public class Organisation
  {
    public Organisation(string name, string logo, string registrationNumber)
    {
      Name = name;
      Logo = logo;

      RegistrationNumber = registrationNumber;
    }

    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }

    public Address? AdressModel { get; set; }
    public string RegistrationNumber { get; set; }
  }
}