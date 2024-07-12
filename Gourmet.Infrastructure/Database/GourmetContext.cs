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
                eb.HasMany(e => e.Dishes)
                    .WithMany(e => e.Users)
                    .UsingEntity<FavoriteUserDish>()
                    ;
                // Связь пользователя и любимых блюд другого пользователя, которые 1-й пользователь лайкнул.
                eb.HasMany(e => e.LikedFavoriteDishes)
                    .WithMany(e => e.LikedUsersDishes)
                    .UsingEntity<LikedUserFavorite>(
                        l => l.HasOne<FavoriteUserDish>(e => e.Favorite).WithMany().OnDelete(DeleteBehavior.Restrict),
                        r => r.HasOne<User>(e => e.User).WithMany().OnDelete(DeleteBehavior.Restrict)
                    );

                // Maps to table
                eb.ToTable(TablesConst.NameUsersTable);
            });


            modelBuilder.Entity<Dish>(eb =>
            {
                // Primary key
                eb.HasKey(e => e.Id);

                // Limit the size of columns to use efficient database types
                //eb.Property(b => b.Id).ValueGeneratedOnAdd();
                eb.Property(e => e.Name).HasMaxLength(TablesConst.DishFldNameLenght).IsRequired();

                // Maps to table
                eb.ToTable(TablesConst.NameDishesTable);
            });

            modelBuilder.Entity<FavoriteUserDish>(eb =>
            {
                // Primary key
                eb.HasKey(e => e.Id);

                // Index
                eb.HasIndex(x => new { x.UserId, x.DishId }).IsUnique();

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
