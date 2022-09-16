using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Identity.API.Factories
{
  public class PersistedGrantDbContextFactory : IDesignTimeDbContextFactory<PersistedGrantDbContext>
  {
    public PersistedGrantDbContext CreateDbContext(string[] args)
    {
      var config = new ConfigurationBuilder()
         .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
         .AddJsonFile("appsettings.json")
         .AddEnvironmentVariables()
         .AddUserSecrets(Assembly.GetAssembly(typeof(Startup)))
         .Build();

      var optionsBuilder = new DbContextOptionsBuilder<PersistedGrantDbContext>();
      var operationOptions = new OperationalStoreOptions();

      optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"), sqlServerOptionsAction: o => o.MigrationsAssembly(typeof(Startup).Assembly.FullName));


      return new PersistedGrantDbContext(optionsBuilder.Options, operationOptions);
    }
  }
}