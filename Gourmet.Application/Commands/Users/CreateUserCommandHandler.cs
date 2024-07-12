using Gourmet.Domain;
using Gourmet.Domain.Repositories;
using MediatR;

namespace Gourmet.Application.Commands.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserCommandsRepository _userRepository;

        public CreateUserCommandHandler(IUserCommandsRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User(command.Name, command.Sex, command.Age);

            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
