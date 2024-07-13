using Gourmet.Application.Queries.Users;
using Gourmet.Domain;
using Gourmet.Domain.Enums;
using Gourmet.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Gourmet.Infrastructure.RepositoriesQueries
{
    public class UserQueriesRepository : IUserQueriesRepository
    {
        private readonly GourmetContext _db;

        public UserQueriesRepository(GourmetContext db)
        {
            _db = db;
            db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<List<User>> GetFilterUsersAsync(int userId, SexType sex, int age, IEnumerable<int>? dishIds = null)
        {
            IQueryable<User> usersQuery = _db.Users
                .Where(x => 
                    x.Id != userId
                    && x.Sex == sex
                    && x.Age == age
                );

            if (dishIds != null && dishIds.Count() > 0)
            {
                usersQuery = usersQuery.Where(x => x.FavoriteDishes.Any(d => dishIds!.Contains(d.DishId)));
            }

            return await usersQuery.ToListAsync();
        }
    }
}
