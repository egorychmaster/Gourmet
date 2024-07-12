using Gourmet.Domain.Enums;

namespace Gourmet.Application.Queries.Users
{
    public class UserDTO
    {
        public UserDTO(int id, string name, SexType sex, int age)
        {
            Id = id;
            Name = name;
            Sex = sex;
            Age = age;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public SexType Sex { get; set; }

        public int Age { get; set; }
    }
}
