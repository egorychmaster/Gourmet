namespace Gourmet.Application.Queries.Favorites.DTOs
{
    public class DishDTO
    {
        public DishDTO(int id, string name) 
        { 
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
