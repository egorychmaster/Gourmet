namespace Gourmet.Domain
{
    /// <summary>
    /// Любимое блюдо пользователя в его списке.
    /// </summary>
    public class FavoriteUserDish
    {
        public FavoriteUserDish()
        { }

        public int Id { get; set; }

        public int UserId { get; set; }
        public int DishId { get; set; }

        //public User User { get; set; } = null!;
        //public Dish Dish { get; set; } = null!;

        public List<User> LikedUsersDishes { get; set; } = [];
    }
}
