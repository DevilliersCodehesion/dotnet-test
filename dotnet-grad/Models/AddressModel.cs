using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_grad.Models
{
  public class AddressModel
  {
    public AddressModel(string line, string line2, string city, string state, int code)
    {
      this.line = line;
      this.line2 = line2;
      this.city = city;
      this.state = state;
      this.code = code;
    }

    [Key] public int id { get; set; }
    public string line { get; set; }
    public string line2 { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public int code { get; set; }
  }
}

