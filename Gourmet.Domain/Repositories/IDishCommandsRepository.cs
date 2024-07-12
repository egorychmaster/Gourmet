namespace Gourmet.Domain.Repositories
{
    public interface IDishCommandsRepository
    {
        Task<Dish> GetAsync(int id);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
