using Gourmet.Domain.Exceptions;
using Gourmet.Domain.Repositories;
using MediatR;

namespace Gourmet.Application.Commands
{
    public class UpdateUserCommandHander : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IUserCommandsRepository _userRepository;

        public UpdateUserCommandHander(IUserCommandsRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(command.Id);
            if (user == null) throw new NotFoundException($"User not found with id={command.Id}.");

            user.Name = command.Name;
            user.Sex = command.Sex;
            user.Age = command.Age;

            await _userRepository.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
