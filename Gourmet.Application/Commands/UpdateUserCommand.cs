using Gourmet.Domain.Enums;
using MediatR;

namespace Gourmet.Application.Commands
{
    public class UpdateUserCommand : IRequest<int>
    {
        public UpdateUserCommand(int id, string name, SexType sex, int age)
        {
            Id = id;
            Name = name;
            Sex = sex;
            Age = age;
        }

        public int Id { get; set; }

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
