namespace Gourmet.Domain.Repositories
{
    public interface IUserCommandsRepository
    {
        Task<User> GetAsync(int id);

        void Add(User item);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
