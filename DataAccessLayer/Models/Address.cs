using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
  public class Address
  {
    public Address(string line, string line2, string city, string state, int code)
    {
      this.Line = line;
      this.Line2 = line2;
      this.City = city;
      this.State = state;
      this.Code = code;
    }

    [Key] public int Id { get; set; }
    public string Line { get; set; }
    public string Line2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int Code { get; set; }
  }
}