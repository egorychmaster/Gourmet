using MediatR;

namespace Gourmet.Application.Commands.Favorites
{
    public class AddFavoriteDishToUserCommand : IRequest<bool>
    {
        public AddFavoriteDishToUserCommand(int id, int dishId)
        {
            Id = id;
            DishId = dishId;
        }

        public int Id { get; }
        public int DishId { get; }
    }
}
