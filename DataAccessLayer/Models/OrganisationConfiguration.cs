using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Models
{
  public class OrganisationConfiguration
  {
    public void Configure(EntityTypeBuilder<Organisation> builder)
    {
      builder.OwnsOne(x => x.AdressModel);
    }
  }
}