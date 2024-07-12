namespace Gourmet.Domain.Repositories
{
    public interface IDishCommandsRepository
    {
        Task<Dish> GetAsync(int id);

        //void Add(Dish item);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
