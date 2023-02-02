using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_grad.Models
{
  public class UserConfiguration
  {
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
      builder.OwnsMany(x => x.organsiation_models);
    }
  }
}