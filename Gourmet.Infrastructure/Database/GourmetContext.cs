using Gourmet.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gourmet.Infrastructure.Database
{
    public class GourmetContext : DbContext
    {
        public GourmetContext(DbContextOptions<GourmetContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>(eb =>
            //{
            //    // Primary key
            //    eb.HasKey(e => e.Id);

            //    // Limit the size of columns to use efficient database types
            //    eb.Property(e => e.Name).HasMaxLength(TableFieldsConst.UserFldNameLenght).IsRequired();
            //    eb.Property(e => e.MiddleName).HasMaxLength(TableFieldsConst.UserFldNameLenght);
            //    eb.Property(e => e.Surname).HasMaxLength(TableFieldsConst.UserFldNameLenght).IsRequired();
            //    eb.Property(e => e.Email).HasMaxLength(TableFieldsConst.UserFldFldEmailLenght);

            //    // Relationships

            //    // Maps to table
            //    eb.ToTable("Users");
            //});


            //modelBuilder.Entity<Organization>(eb =>
            //{
            //    // Primary key
            //    eb.HasKey(e => e.Id);

            //    // Limit the size of columns to use efficient database types
            //    eb.Property(e => e.Name).HasMaxLength(TableFieldsConst.OrganizationFldNameLenght).IsRequired();

            //    // Maps to table
            //    eb.ToTable("Organizations");
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}
