using Gourmet.Domain;
using Gourmet.Domain.Enums;
using Microsoft.EntityFrameworkCore;

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
                eb.Property(e => e.Name).HasMaxLength(TablesConst.UserFldNameLenght).IsRequired();
                eb.Property(e => e.Sex)
                    .HasConversion(
                        v => (int)v,
                        v => (SexType)v);

                // Relationships
                // Связь пользователя и его любимых блюд.
                eb.HasMany(e => e.FavoriteDishes)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId)
                    .IsRequired();
                
                // Связь пользователя и любимых блюд другого пользователя, которые 1-й пользователь лайкнул.
                eb.HasMany(e => e.LikedFavorites)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId)
                    .IsRequired(false)
                    ;

                // Maps to table
                eb.ToTable(TablesConst.NameUsersTable);
            });


            modelBuilder.Entity<Dish>(eb =>
            {
                // Primary key
                eb.HasKey(e => e.Id);

                // Limit the size of columns to use efficient database types
                eb.Property(e => e.Name).HasMaxLength(TablesConst.DishFldNameLenght).IsRequired();

                // Relationships
                eb.HasMany(e => e.FavoriteUsers)
                    .WithOne(e => e.Dish)
                    .HasForeignKey(e => e.DishId)
                    .IsRequired();

                // Maps to table
                eb.ToTable(TablesConst.NameDishesTable);
            });

            modelBuilder.Entity<FavoriteUserDish>(eb =>
            {
                // Primary key
                eb.HasKey(e => e.Id);

                // Index
                eb.HasIndex(x => new { x.UserId, x.DishId }).IsUnique();

                // Relationships
                eb.HasMany(e => e.LikedUsers)
                    .WithOne(e => e.Favorite)
                    .HasForeignKey(e => e.FavoriteId)
                    .IsRequired()
                    ;

                // Maps to table
                eb.ToTable("FavoriteUsersDishes");
            });

            modelBuilder.Entity<LikedUserFavorite>(eb =>
            {
                // Primary key
                eb.HasKey(e => new { e.UserId, e.FavoriteId });

                // Maps to table
                eb.ToTable("LikedUsersFavorites");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
