namespace Gourmet.Domain
{
    /// <summary>
    /// Любимое блюдо пользователя в его списке.
    /// </summary>
    public class FavoriteUserDish
    {
        public FavoriteUserDish() { }

        public FavoriteUserDish(User user, Dish dish)
        { 
            UserId = user.Id;
            User = user;

            DishId = dish.Id;
            Dish = dish;
        }

        public int Id { get; set; }

        public int UserId { get; private set; }
        public int DishId { get; private set; }

        public User User { get; set; } = null!;
        public Dish Dish { get; set; } = null!;

        /// <summary>
        /// Пользователи лайкнувшие блюдо другого пользователя.
        /// </summary>
        public List<LikedUserFavorite> LikedUsers = new List<LikedUserFavorite>();
    }
}
