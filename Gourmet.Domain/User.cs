﻿namespace Gourmet.Domain
{
    public class User
    {
        public User()
        { }

        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Пол.
        /// </summary>
        public bool Sex { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get; set; }


        public List<Dish> Dishes { get; set; } = [];
        //public List<FavoriteUserDish> FavoriteUsersDishes { get; set; } = new();
        //public List<LikedUserFavorite> LikedUsersFavorites { get; set; } = new();
    }
}
