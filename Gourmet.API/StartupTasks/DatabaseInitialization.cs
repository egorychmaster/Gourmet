using Gourmet.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Gourmet.API.StartupTasks
{
    internal class DatabaseInitialization : IHostedService
    {
        private readonly IDbContextFactory<GourmetContext> _dbContextFactory;
        public DatabaseInitialization(IDbContextFactory<GourmetContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                using GourmetContext _dbContext = _dbContextFactory.CreateDbContext();
                await _dbContext.Database.MigrateAsync();

                await InitializeDefaultData.Initialize(_dbContext);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
