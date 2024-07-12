using Gourmet.Application.Queries.Favorites.DTOs;
using MediatR;

namespace Gourmet.Application.Queries.Favorites
{
    public class GetFavoriteDishesByUserQuery : IRequest<IEnumerable<DishDTO>>
    {
        public GetFavoriteDishesByUserQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; private set; }
    }
}
