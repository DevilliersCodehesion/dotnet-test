using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models
{
  public class DatabaseContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<UserInfo> UserInfo { get; set; }

    public string DbPath { get; }
    public DatabaseContext()
    {
      var folder = Environment.SpecialFolder.LocalApplicationData;
      var path = Environment.GetFolderPath(folder);
      DbPath = System.IO.Path.Join(path, "testing.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseSqlite($"Data source={DbPath}");
  }
}