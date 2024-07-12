using System.ComponentModel.DataAnnotations.Schema;

namespace Gourmet.Domain
{
    /// <summary>
    /// Блюдо.
    /// </summary>
    public class Dish
    {
        public Dish()
        { }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } = null!;


        public List<User> Users { get; set; } = [];
    }
}
