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


        #region Favorites
        private List<LikedUserFavorite> _likedUsers = new List<LikedUserFavorite>();
        /// <summary>
        /// Пользователи лайкнувшие блюдо другого пользователя.
        /// </summary>
        public IReadOnlyCollection<LikedUserFavorite> LikedUsers => _likedUsers;
        #endregion Favorites


        public void AddLike(User user)
        {
            // Этот пользователь уже поставил лайк ранее.
            if (_likedUsers.Any(x => x.UserId == user.Id))
                return;

            _likedUsers.Add(new LikedUserFavorite(user, this));
        }

        public void DeleteAllLikes()
        {
            _likedUsers.Clear();
        }
    }
}
