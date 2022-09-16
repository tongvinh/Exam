using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore.Design;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Factories
{
  public class ConfigurationDbContextFactory : IDesignTimeDbContextFactory<ConfigurationDbContext>
  {
    public ConfigurationDbContext CreateDbContext(string[] args)
    {
      var config = new ConfigurationBuilder()
        .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .AddUserSecrets(Assembly.GetAssembly(typeof(Startup)))
        .Build();

      var optionsBuilder = new DbContextOptionsBuilder<ConfigurationDbContext>();
      var storeOptions = new ConfigurationStoreOptions();

      optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"), sqlServerOptionsAction: o => o.MigrationsAssembly(typeof(Startup).Assembly.FullName));


      return new ConfigurationDbContext(optionsBuilder.Options, storeOptions);
    }
  }
}