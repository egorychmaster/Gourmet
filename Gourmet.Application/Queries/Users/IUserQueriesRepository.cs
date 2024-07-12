using Gourmet.Domain;
using Gourmet.Domain.Enums;

namespace Gourmet.Application.Queries.Users
{
    public interface IUserQueriesRepository
    {
        Task<List<User>> GetFilterUsersAsync(int userId, SexType sex, int age, IEnumerable<int> dishIds = null);
    }
}
