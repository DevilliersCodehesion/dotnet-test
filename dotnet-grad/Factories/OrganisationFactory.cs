using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_grad.Models;

namespace dotnet_grad.Factories
{
  public class OrganisationFactory
  {
    public static OrganisationModel create(string name, string logo, string registrationNumber)
    {
      return new OrganisationModel(name, logo, registrationNumber);
    }
  }
}