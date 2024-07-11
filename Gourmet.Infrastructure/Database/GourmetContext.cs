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

                // Relationships
                eb.HasMany(e => e.Dishes)
                    .WithMany(e => e.Users)
                    .UsingEntity<FavoriteUserDish>()
                    ;

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

            modelBuilder.Entity<FavoriteUserDish>(eb =>
            {
                // Primary key
                eb.HasKey(e => e.Id);

                // Index
                eb.HasIndex(x => new { x.UserId, x.DishId }).IsUnique();

                //eb.HasOne(e => e.User)
                //    .WithMany(e => e.FavoriteUsersDishes)
                //    .HasForeignKey(e => e.UserId)
                //    .IsRequired()
                //    ;

                //eb.HasOne(e => e.Dish)
                //    .WithMany()//e => e.FavoriteUsersDishes)
                //    .HasForeignKey(e => e.DishId)
                //    .IsRequired()
                //    ;

                // Maps to table
                eb.ToTable("FavoriteUsersDishes");
            });

            //modelBuilder.Entity<LikedUserFavorite>(eb =>
            //{
            //    // Primary key
            //    eb.HasKey(e => new { e.UserId, e.FavoriteId });

            //    eb.HasOne(e => e.User)
            //        .WithMany(e => e.LikedUsersFavorites)
            //        .HasForeignKey(e => e.UserId)
            //        .IsRequired(false)
            //        ;

            //    //eb.HasOne(e => e.FavoriteUserDish)
            //    //    .WithMany(e => e.LikedUsersFavorites)
            //    //    .HasForeignKey(e => e.FavoriteId)
            //    //    .IsRequired();

            //    // Maps to table
            //    eb.ToTable("LikedUsersFavorites");
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}
