using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gourmet.Domain
{
    /// <summary>
    /// Лайки пользователя на любимое блюдо из списка другого пользователя.
    /// </summary>
    public class LikedUsersFavorite
    {
        public int UserId { get; set; }
        public int FavoriteId { get; set; }

        public User User { get; set; }
        public FavoriteUsersDish Favorite { get; set; }
    }
}
