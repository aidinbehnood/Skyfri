using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyfriSample.Data.Entity
{
    public class SkyfriContext : DbContext
    {

        protected readonly IConfiguration Configuration;
        public SkyfriContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
  
            options.UseSqlServer(Configuration.GetConnectionString("SkyfriConnection"));

        }

        public DbSet<Tenant>  Tenants { get; set; }
        public DbSet<Portfolio>  Portfolios { get; set; }

    }
}
