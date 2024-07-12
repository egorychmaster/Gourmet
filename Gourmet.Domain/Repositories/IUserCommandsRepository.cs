namespace Gourmet.Domain.Repositories
{
    public interface IUserCommandsRepository
    {
        Task<User> GetAsync(int id);

        void Add(User item);

        /// <summary>
        /// Добавить любимое блюдо пользователю.
        /// </summary>
        void AddFavoriteDishToUser(User user, Dish dish);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
