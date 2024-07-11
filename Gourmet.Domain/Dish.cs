using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gourmet.Domain
{
    /// <summary>
    /// Блюдо.
    /// </summary>
    public class Dish
    {
        public Dish()
        { }

        public int Id { get; set; }

        public string Name { get; set; } = null!;


        public List<User> Users { get; set; } = [];
        //public List<FavoriteUserDish> FavoriteUsersDishes { get; set; } = new();
    }
}
