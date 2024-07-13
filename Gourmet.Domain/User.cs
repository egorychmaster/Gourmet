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
        //private List<Dish> _dishes = new List<Dish>();
        //public IReadOnlyCollection<Dish> Dishes => _dishes;
        //public IReadOnlyCollection<Dish> Dishes => FavoriteDishes.Di;
        public List<FavoriteUserDish> FavoriteDishes = new List<FavoriteUserDish>();
        #endregion Favorites


        #region Like
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
            FavoriteDishes.Add(new FavoriteUserDish(this, dish));
        }

        public void RemoveDish(int dishId)
        {
            FavoriteDishes = FavoriteDishes.Where(x => x.DishId != dishId).ToList();
        }

        /// <summary>
        /// Поставить лайк блюду.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="dishId"></param>
        /// <exception cref="Exception"></exception>
        //public void SetLikeDish(User user, int dishId)
        //{
        //    var favoriteDish = FavoriteDishes.FirstOrDefault(x => x.DishId == dishId);
        //    if (favoriteDish == null)
        //        throw new Exception("Dish not found.");

        //    // Уже лайкал этот пользователь.
        //    if (favoriteDish!.LikedUsersDishes.Any(x => x.Id == user.Id))
        //        return;

        //    favoriteDish.LikedUsersDishes.Add(user);
        //}
        #endregion Dishes
    }
}
