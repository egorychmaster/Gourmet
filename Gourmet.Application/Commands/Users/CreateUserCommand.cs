using Gourmet.Domain.Enums;
using MediatR;

namespace Gourmet.Application.Commands.Users
{
    public class CreateUserCommand : IRequest<int>
    {
        public CreateUserCommand(string name, SexType sex, int age)
        {
            Name = name;
            Sex = sex;
            Age = age;
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Пол.
        /// </summary>
        public SexType Sex { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get; set; }
    }
}
