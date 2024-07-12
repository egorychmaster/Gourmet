using Gourmet.Domain;
using Gourmet.Domain.Repositories;
using Gourmet.Infrastructure.Database;

namespace Gourmet.Infrastructure.RepositoriesCommands
{
    public class UserCommandsRepository : IUserCommandsRepository
    {
        private readonly GourmetContext _context;

        public UserCommandsRepository(GourmetContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> GetAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Add(User item)
        {
            _context.Users.Add(item);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
