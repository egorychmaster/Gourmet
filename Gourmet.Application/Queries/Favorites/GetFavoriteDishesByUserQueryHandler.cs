using Gourmet.Application.Queries.Favorites.DTOs;
using MediatR;

namespace Gourmet.Application.Queries.Favorites
{
    public class GetFavoriteDishesByUserQueryHandler : IRequestHandler<GetFavoriteDishesByUserQuery, IEnumerable<DishDTO>>
    {
        private readonly IFavoriteQueriesRepository _favoriteQueries;

        public GetFavoriteDishesByUserQueryHandler(IFavoriteQueriesRepository favoriteQueries)
        {
            _favoriteQueries = favoriteQueries;
        }

        public async Task<IEnumerable<DishDTO>> Handle(GetFavoriteDishesByUserQuery request, CancellationToken cancellationToken)
        {
            var dishes = await _favoriteQueries.GetDishesByUserAsync(request.UserId);

            return dishes.Select(x => new DishDTO(x.Id, x.Name));
        }
    }
}
