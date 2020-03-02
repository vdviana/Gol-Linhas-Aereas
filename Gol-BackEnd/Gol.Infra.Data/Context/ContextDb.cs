using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Gol.Domain.Entities;
using Gol.Infra.Data.Mapping;

namespace Gol.Infra.Data.Context
{
    public class ContextDb : DbContext
    {

        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {

        }

        public DbSet<Travel> Travels{ get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Travel>(new TravelMap().Configure);
            modelBuilder.Entity<AuthUser>(new AuthUserMap().Configure);

        }

        public override int SaveChanges()
        {
            try
            {
                foreach (var item in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreationDate") != null))
                {
                    if (item.State == EntityState.Added)
                    {
                        item.Property("CreationDate").CurrentValue = DateTime.Now;
                    }

                    if (item.State == EntityState.Modified)
                    {
                        item.Property("CreationDate").IsModified = false;
                    }
                }
                return base.SaveChanges();
            }
            catch (Exception ex) 
            {

                return 0;
            
            }
        }
    }


}
