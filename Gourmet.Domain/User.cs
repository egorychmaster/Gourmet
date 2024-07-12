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


        private List<Dish> _dishes = new List<Dish>();
        public IReadOnlyCollection<Dish> Dishes => _dishes;


        private List<FavoriteUserDish> _likedFavoriteDishes = new List<FavoriteUserDish>();
        public IReadOnlyCollection<FavoriteUserDish> LikedFavoriteDishes => _likedFavoriteDishes;


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
            _dishes.Add(dish);
        }

        public void RemoveDish(Dish dish)
        {
            _dishes.Remove(dish);
        }
        #endregion Dishes
    }
}
