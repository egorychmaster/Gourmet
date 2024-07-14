using Gourmet.Domain.Enums;
using MediatR;

namespace Gourmet.Application.Queries.Users
{
    public class GetFilterUsersQuery : IRequest<IEnumerable<UserDTO>>
    {
        public GetFilterUsersQuery(int currentUserId, SexType sex, int age, IEnumerable<int>? dishIds) 
        {
            CurrentUserId = currentUserId;
            Sex = sex;
            Age = age;
            DishIds = dishIds;
        }

        public int CurrentUserId { get; set; }

        public SexType Sex { get; set; }

        public int Age { get; set; }

        public IEnumerable<int>? DishIds { get; set; }
    }
}
