using Gourmet.Application.Queries.Favorites;
using Gourmet.Domain;
using Gourmet.Domain.Exceptions;
using Gourmet.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Gourmet.Infrastructure.RepositoriesQueries
{
    public class FavoriteQueriesRepository: IFavoriteQueriesRepository
    {
        private readonly GourmetContext _db;

        public FavoriteQueriesRepository(GourmetContext db)
        {
            _db = db;
            db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<IEnumerable<Dish>> GetDishesByUserAsync(int userId)
        {
            var user = await _db.Users
                .Include(x => x.FavoriteDishes).ThenInclude(x => x.Dish)
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null) throw new NotFoundException($"User with id={userId} not found.");

            return user.FavoriteDishes.Select(x => x.Dish).ToList();
        }
    }
}
