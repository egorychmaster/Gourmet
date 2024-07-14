using Gourmet.Domain.Exceptions;
using Gourmet.Domain.Repositories;
using MediatR;

namespace Gourmet.Application.Commands.Favorites
{
    public class AddFavoriteDishToUserCommandHandler : IRequestHandler<AddFavoriteDishToUserCommand, bool>
    {
        private readonly IUserCommandsRepository _userRepository;
        private readonly IDishCommandsRepository _dishRepository;

        public AddFavoriteDishToUserCommandHandler(IUserCommandsRepository userRepository, IDishCommandsRepository dishRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _dishRepository = dishRepository ?? throw new ArgumentNullException(nameof(dishRepository));
        }

        public async Task<bool> Handle(AddFavoriteDishToUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(command.Id);
            if (user == null) 
                throw new NotFoundException($"User not found with id={command.Id}.");

            var dish = await _dishRepository.GetAsync(command.DishId);
            if (dish == null) 
                throw new NotFoundException($"Dish with id={command.DishId} not found.");

            if(user.FavoriteDishes.Any(x => x.DishId == command.DishId))
                throw new NotFoundException($"The dish has already been added to favorites.");

            user.AddDish(dish);
            await _userRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
