using Gourmet.Domain;
using Gourmet.Domain.Repositories;
using Gourmet.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

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
            return await _context.Users
                .Include(x => x.FavoriteDishes).ThenInclude(x => x.Dish)
                .Include(x => x.FavoriteDishes).ThenInclude(x => x.LikedUsers)
                .Include(x => x.LikedFavorites)
                .FirstOrDefaultAsync(x => x.Id == id);
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
