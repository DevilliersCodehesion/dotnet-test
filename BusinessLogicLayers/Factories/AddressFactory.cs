using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayers.Factories
{
  public class AddressFactory
  {
    public static Address create(string line1, string line2, string city, string state, int code)
    {
      return new Address(line1, line2, city, state, code);
    }
  }
}