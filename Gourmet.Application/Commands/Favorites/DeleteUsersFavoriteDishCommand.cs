using MediatR;

namespace Gourmet.Application.Commands.Favorites
{
    public class DeleteUsersFavoriteDishCommand : IRequest<bool>
    {
        public DeleteUsersFavoriteDishCommand(int id, int dishId)
        {
            Id = id;
            DishId = dishId;
        }

        public int Id { get; }
        public int DishId { get; }
    }
}
