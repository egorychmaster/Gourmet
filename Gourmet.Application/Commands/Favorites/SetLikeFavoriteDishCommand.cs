using MediatR;

namespace Gourmet.Application.Commands.Favorites
{
    public class SetLikeFavoriteDishCommand : IRequest<bool>
    {
        public SetLikeFavoriteDishCommand(int currentUserId, int dishId, int userId)
        {
            CurrentUserId = currentUserId;
            DishId = dishId;
            UserId = userId;
        }

        public int CurrentUserId { get; }
        public int DishId { get; }
        public int UserId { get; }
    }
}
