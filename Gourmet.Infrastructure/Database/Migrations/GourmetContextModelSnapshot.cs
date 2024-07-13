﻿// <auto-generated />
using Gourmet.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gourmet.Infrastructure.Database.Migrations
{
    [DbContext(typeof(GourmetContext))]
    partial class GourmetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gourmet.Domain.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Dishes", (string)null);
                });

            modelBuilder.Entity("Gourmet.Domain.FavoriteUserDish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("UserId", "DishId")
                        .IsUnique();

                    b.ToTable("FavoriteUsersDishes", (string)null);
                });

            modelBuilder.Entity("Gourmet.Domain.LikedUserFavorite", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("FavoriteId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "FavoriteId");

                    b.HasIndex("FavoriteId");

                    b.ToTable("LikedUsersFavorites", (string)null);
                });

            modelBuilder.Entity("Gourmet.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Gourmet.Domain.FavoriteUserDish", b =>
                {
                    b.HasOne("Gourmet.Domain.Dish", "Dish")
                        .WithMany("FavoriteUsers")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gourmet.Domain.User", "User")
                        .WithMany("FavoriteDishes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gourmet.Domain.LikedUserFavorite", b =>
                {
                    b.HasOne("Gourmet.Domain.FavoriteUserDish", "Favorite")
                        .WithMany("LikedUsers")
                        .HasForeignKey("FavoriteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gourmet.Domain.User", "User")
                        .WithMany("LikedFavorites")
                        .HasForeignKey("UserId");

                    b.Navigation("Favorite");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gourmet.Domain.Dish", b =>
                {
                    b.Navigation("FavoriteUsers");
                });

            modelBuilder.Entity("Gourmet.Domain.FavoriteUserDish", b =>
                {
                    b.Navigation("LikedUsers");
                });

            modelBuilder.Entity("Gourmet.Domain.User", b =>
                {
                    b.Navigation("FavoriteDishes");

                    b.Navigation("LikedFavorites");
                });
#pragma warning restore 612, 618
        }
    }
}
