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
            if (user.Dishes.Any(x => x.Id == command.DishId)) 
                throw new Exception($"Dish with id={command.DishId} already exists.");

            var dish = await _dishRepository.GetAsync(command.DishId);
            if (dish == null) 
                throw new NotFoundException($"Dish with id={command.DishId} not found.");

            user.AddDish(dish);
            await _userRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
