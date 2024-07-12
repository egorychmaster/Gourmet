using Gourmet.Domain;

namespace Gourmet.Application.Queries.Favorites
{
    public interface IFavoriteQueriesRepository
    {
        Task<IEnumerable<Dish>> GetDishesByUserAsync(int userId);
    }
}
