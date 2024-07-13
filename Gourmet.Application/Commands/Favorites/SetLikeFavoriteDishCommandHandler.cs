using Gourmet.Domain.Exceptions;
using Gourmet.Domain.Repositories;
using MediatR;

namespace Gourmet.Application.Commands.Favorites
{
    public class SetLikeFavoriteDishCommandHandler : IRequestHandler<SetLikeFavoriteDishCommand, bool>
    {
        private readonly IUserCommandsRepository _userRepository;
        private readonly IDishCommandsRepository _dishRepository;

        public SetLikeFavoriteDishCommandHandler(IUserCommandsRepository userRepository, IDishCommandsRepository dishRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _dishRepository = dishRepository ?? throw new ArgumentNullException(nameof(dishRepository));
        }

        public async Task<bool> Handle(SetLikeFavoriteDishCommand command, CancellationToken cancellationToken)
        {
            if(command.CurrentUserId == command.UserId)
                throw new NotFoundException($"The user cannot like himself.");

            var currentUser = await _userRepository.GetAsync(command.CurrentUserId);
            if (currentUser == null)
                throw new NotFoundException($"CurrentUserId not found with id={command.CurrentUserId}.");

            var user = await _userRepository.GetAsync(command.UserId);
            if (user == null)
                throw new NotFoundException($"User not found with id={command.UserId}.");

            user.SetLikeDish(currentUser, command.DishId);
            await _userRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
