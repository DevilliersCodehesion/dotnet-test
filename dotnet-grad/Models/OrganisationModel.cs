using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace dotnet_grad.Models
{
  public class OrganisationModel
  {
    public OrganisationModel(string name, string logo, string registrationNumber)
    {
      Name = name;
      Logo = logo;

      RegistrationNumber = registrationNumber;
    }

    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }

    public AddressModel AdressModel { get; set; }
    public string RegistrationNumber { get; set; }

  }
}

