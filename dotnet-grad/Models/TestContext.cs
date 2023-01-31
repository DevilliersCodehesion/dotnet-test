using System;
using Microsoft.EntityFrameworkCore;

namespace dotnet_grad.Models
{
  public class TestContext : DbContext
  {

    public DbSet<UserModel> Users { get; set; }
    public DbSet<OrganisationModel> Organisations { get; set; }
    public DbSet<AddressModel> Addresses { get; set; }

    public string DbPath { get; }
    public TestContext()
    {
      var folder = Environment.SpecialFolder.LocalApplicationData;
      var path = Environment.GetFolderPath(folder);
      DbPath = System.IO.Path.Join(path, "testing.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseSqlite($"Data source={DbPath}");

  }
}

