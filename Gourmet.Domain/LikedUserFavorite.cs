namespace Gourmet.Domain
{
    /// <summary>
    /// Лайки пользователя на любимое блюдо из списка другого пользователя.
    /// </summary>
    public class LikedUserFavorite
    {
        public LikedUserFavorite()
        { }

        public int UserId { get; set; }
        public int FavoriteId { get; set; }

        public User User { get; set; } = null!;
        public FavoriteUserDish Favorite { get; set; } = null!;
    }
}
