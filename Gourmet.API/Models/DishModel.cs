namespace Gourmet.API.Models
{
    public class DishModel
    {
        public DishModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Идентификатор блюда.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование блюда.
        /// </summary>
        public string Name { get; set; }
    }
}
