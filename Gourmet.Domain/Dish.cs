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


        public List<FavoriteUserDish> FavoriteUsers { get; set; } = [];
        //public List<User> Users { get; set; } = [];
    }
}
