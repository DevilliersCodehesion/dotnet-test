using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Models
{
  public class UserConfiguration
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.OwnsMany(x => x.Organisations);
    }
  }
}