using Gourmet.Domain.Exceptions;
using Gourmet.Domain.Repositories;
using MediatR;

namespace Gourmet.Application.Commands.Users
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

            user.SetName(command.Name);
            user.SetSex(command.Sex);
            user.SetAge(command.Age);

            await _userRepository.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
