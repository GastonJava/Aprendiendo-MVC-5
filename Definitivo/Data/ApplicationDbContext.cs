using System;
using System.Collections.Generic;
using System.Text;
using Definitivo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Definitivo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<UsuarioModelCustom> Usuario { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ApplicationDbContext>(b =>
            //{
                // Each Role can have many entries in the UserRole join table
                //b.HasMany(e => e.E)
                //    .WithOne(e => e.Role)
                //    .HasForeignKey(ur => ur.RoleId)
                //    .IsRequired();

                // Each Role can have many associated RoleClaims
                //b.HasMany(e => e.RoleClaims)
                //    .WithOne(e => e)
                //    .HasForeignKey(rc => rc.RoleId)
                //    .IsRequired();
            //});
        }
    }
}