using Gourmet.Domain;

namespace Gourmet.Application.Queries.Favorites
{
    public interface IFavoriteQueriesRepository
    {
        Task<List<Dish>> GetDishesByUserAsync(int userId);
    }
}
