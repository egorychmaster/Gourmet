using Gourmet.Domain.Exceptions;
using Gourmet.Domain.Repositories;
using MediatR;

namespace Gourmet.Application.Commands.Favorites
{
    public class DeleteUsersFavoriteDishCommandHandler : IRequestHandler<DeleteUsersFavoriteDishCommand, bool>
    {
        private readonly IUserCommandsRepository _userRepository;
        private readonly IDishCommandsRepository _dishRepository;

        public DeleteUsersFavoriteDishCommandHandler(IUserCommandsRepository userRepository, IDishCommandsRepository dishRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _dishRepository = dishRepository ?? throw new ArgumentNullException(nameof(dishRepository));
        }

        public async Task<bool> Handle(DeleteUsersFavoriteDishCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(command.Id);
            if (user == null)
                throw new NotFoundException($"User not found with id={command.Id}.");

            user.RemoveDish(command.DishId);
            await _userRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
