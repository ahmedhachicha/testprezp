using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testprezp.Models
{
    public class AuthenticationContext : IdentityDbContext
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApplicationUserModel>()
                .HasMany(x => x.sent)
                .WithOne(x => x.sender);
            modelBuilder.Entity<ApplicationUserModel>()
       .HasMany(x => x.received)
       .WithOne(x => x.receiver);
            base.OnModelCreating(modelBuilder);


        }

        public DbSet<Request> Requests { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
