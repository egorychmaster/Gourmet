using Gourmet.Domain;
using Gourmet.Domain.Repositories;
using Gourmet.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Gourmet.Infrastructure.RepositoriesCommands
{
    public class DishCommandsRepository : IDishCommandsRepository
    {
        private readonly GourmetContext _context;

        public DishCommandsRepository(GourmetContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Dish> GetAsync(int id)
        {
            return await _context.Dishes
                //.Include(x => x.Dishes)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
