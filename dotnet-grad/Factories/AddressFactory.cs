using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_grad.Models;

namespace dotnet_grad.Factories
{
  public class AddressFactory
  {
    public static AddressModel create(string line1, string line2, string city, string state, int code)
    {
      return new AddressModel(line1, line2, city, state, code);
    }
  }
}