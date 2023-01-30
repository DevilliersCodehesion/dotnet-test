using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace dotnet_grad.Models
{
  public class OrganisationModel
  {
    public OrganisationModel(string name, string logo, int registration_number)
    {
      this.name = name;
      this.logo = logo;

      this.registration_number = registration_number;
    }

    [Key] public int id { get; set; }
    public string name { get; set; }
    public string logo { get; set; }

    public AddressModel adress_model
    {
      get;
    }
    public int registration_number { get; set; }


  }
}

