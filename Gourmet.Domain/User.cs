using Gourmet.Domain.Enums;

namespace Gourmet.Domain
{
    public class User
    {
        public User(string name, SexType sex, int age)
        {
            Name = name;
            Sex = sex;
            Age = age;
        }

        public int Id { get; private set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; private set; } = null!;

        /// <summary>
        /// Пол.
        /// </summary>
        public SexType Sex { get; private set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get; private set; }


        #region Favorites
        private List<FavoriteUserDish> _favoriteDishes = new List<FavoriteUserDish>();
        /// <summary>
        /// Список любимых блюд.
        /// </summary>
        public IReadOnlyCollection<FavoriteUserDish> FavoriteDishes => _favoriteDishes;
        #endregion Favorites


        #region Like
        public List<LikedUserFavorite> LikedFavorites = new List<LikedUserFavorite>();
        //private List<FavoriteUserDish> _favoriteDishes = new List<FavoriteUserDish>();
        //public IReadOnlyCollection<FavoriteUserDish> FavoriteDishes => _favoriteDishes;

        #endregion Like

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException($"{nameof(name)}");

            Name = name;
        }

        public void SetSex(SexType sex)
        {
            Sex = sex;
        }

        public void SetAge(int age)
        {
            if (0 < age && age < 200)
                Age = age;
            else
                throw new Exception($"{nameof(age)}");
        }


        #region Dishes
        public void AddDish(Dish dish)
        {
            _favoriteDishes.Add(new FavoriteUserDish(this, dish));
        }

        public void RemoveDish(int dishId)
        {
            _favoriteDishes = _favoriteDishes.Where(x => x.DishId != dishId).ToList();
        }

        /// <summary>
        /// Поставить лайк блюду.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="dishId"></param>
        /// <exception cref="Exception"></exception>
        public void SetLikeDish(User user, int dishId)
        {
            var favoriteDish = FavoriteDishes.FirstOrDefault(x => x.DishId == dishId);
            if (favoriteDish == null)
                throw new Exception("Dish not found in favorites.");

            // Этот пользователь уже поставил лайк ранее.
            if (user.LikedFavorites.Any(x => x.UserId == user.Id && x.FavoriteId == favoriteDish.Id))
                return;

            user.LikedFavorites.Add(new LikedUserFavorite(user, favoriteDish));
        }
        #endregion Dishes
    }
}
