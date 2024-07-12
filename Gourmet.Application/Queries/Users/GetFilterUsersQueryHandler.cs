using MediatR;

namespace Gourmet.Application.Queries.Users
{
    public class GetFilterUsersQueryHandler : IRequestHandler<GetFilterUsersQuery, IEnumerable<UserDTO>>
    {
        private readonly IUserQueriesRepository _userQueries;

        public GetFilterUsersQueryHandler(IUserQueriesRepository userQueries)
        {
            _userQueries = userQueries ?? throw new ArgumentNullException(nameof(userQueries));
        }

        public async Task<IEnumerable<UserDTO>> Handle(GetFilterUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userQueries.GetFilterUsersAsync(request.UserId, request.Sex, request.Age, request.DishIds);

            return users.Select(x => new UserDTO(x.Id, x.Name, x.Sex, x.Age));
        }
    }
}
