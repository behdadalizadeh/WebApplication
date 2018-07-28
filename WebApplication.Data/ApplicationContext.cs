using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Core.Entities;

namespace WebApplication.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public virtual DbSet<Users> Users { get; set; }

        //Just for Migration
        public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
        {
            public ApplicationContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<ApplicationContext>();
                builder.UseSqlServer("Data Source=.;Initial Catalog=WebApplication;Persist Security Info=True;User ID=sa; Password=95; MultipleActiveResultSets=True");
                return new ApplicationContext(builder.Options);
            }
        }
    }
}