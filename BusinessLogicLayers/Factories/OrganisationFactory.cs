using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayers.Factories
{
  public class OrganisationFactory
  {
    public static Organisation create(string name, string logo, string registrationNumber)
    {
      return new Organisation(name, logo, registrationNumber);
    }
  }
}