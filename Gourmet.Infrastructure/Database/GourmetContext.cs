using Gourmet.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
            modelBuilder.Entity<User>(eb =>
            {
                // Primary key
                eb.HasKey(e => e.Id);

                // Limit the size of columns to use efficient database types
                eb.Property(e => e.Name).HasMaxLength(TableFieldsConst.UserFldNameLenght).IsRequired();

                //// Relationships
                //eb.HasMany(c => c.Dishes)
                //.WithMany(s => s.Users)
                ////.UsingEntity<FavoriteUsersDish>()
                //.UsingEntity<FavoriteUsersDish>(f =>
                //{
                //    // Primary key
                //    f.HasKey(x => x.Id);

                //    // Index
                //    //f.HasIndex(x => new { x.UserId, x.DishId }).IsUnique();

                //    //f.ToTable("FavoriteUsersDishes");
                //})
                //;

                // Maps to table
                eb.ToTable("Users");
            });


            modelBuilder.Entity<Dish>(eb =>
            {
                // Primary key
                eb.HasKey(e => e.Id);

                // Limit the size of columns to use efficient database types
                eb.Property(e => e.Name).HasMaxLength(TableFieldsConst.DishFldNameLenght).IsRequired();

                // Maps to table
                eb.ToTable("Dishes");
            });

            modelBuilder.Entity<FavoriteUsersDish>(eb =>
            {
                // Primary key
                eb.HasKey(e => e.Id);

                // Index
                eb.HasIndex(x => new { x.UserId, x.DishId }).IsUnique();

                eb.HasOne(e => e.User)
                    .WithMany(e => e.FavoriteDishes)
                    .HasForeignKey(e => e.UserId)
                    .IsRequired();

                eb.HasOne(e => e.Dish)
                    .WithMany(e => e.FavoriteUsers)
                    .HasForeignKey(e => e.DishId)
                    .IsRequired();

                // Maps to table
                eb.ToTable("FavoriteUsersDishes");
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
