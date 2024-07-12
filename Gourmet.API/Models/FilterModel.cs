using Gourmet.Domain.Enums;

namespace Gourmet.API.Models
{
    public class FilterModel
    {
        /// <summary>
        /// Пол.
        /// </summary>
        public SexType Sex { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Идентификаторы блюд.
        /// </summary>
        public IEnumerable<int>? DishIds { get; set; } = null;
    }
}
