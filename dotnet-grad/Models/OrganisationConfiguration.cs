using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_grad.Models
{
  public class OrganisationConfiguration : IEntityTypeConfiguration<OrganisationModel>
  {
    public void Configure(EntityTypeBuilder<OrganisationModel> builder)
    {
      builder.OwnsOne(x => x.adress_model);
    }
  }
}