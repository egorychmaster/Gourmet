using Gourmet.Domain.Enums;

namespace Gourmet.API.Models
{
    public class UserModel
    {
        /// <summary> 
        /// Имя 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public SexType Sex  { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get; set; }
    }
}
