using Gourmet.Application.Queries.Users;
using Gourmet.Domain;
using Gourmet.Domain.Enums;
using Gourmet.Infrastructure.Database;
using Gourmet.Infrastructure.RepositoriesQueries;
using Microsoft.EntityFrameworkCore;

namespace Gourmet.UnitTest
{
    public class UsersQueryTest
    {
        private readonly DbContextOptions<GourmetContext> _dbOptions;

        public UsersQueryTest()
        {
            _dbOptions = new DbContextOptionsBuilder<GourmetContext>()
                .UseInMemoryDatabase(databaseName: "in-memory")
                .Options;

            using var dbContext = new GourmetContext(_dbOptions);
            var users = GetFakeUsers();
            dbContext.AddRange(users);
            dbContext.SaveChanges();
        }

        [Fact]
        public async Task GetFilterUsersQuery_Find_One_Man_35_Kapusta()
        {
            //Arrange
            int currentUserId = 100;
            SexType sex = SexType.Man;
            var expectedName = "Вася";
            var expectedCount = 1;

            var gourmetContext = new GourmetContext(_dbOptions);
            var _userQueries = new UserQueriesRepository(gourmetContext);

            //Act
            var _QueryHandler = new GetFilterUsersQueryHandler(_userQueries);

            var filterQuery = new GetFilterUsersQuery(currentUserId, sex, 35, new int[] { 1 });
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            IEnumerable<UserDTO> result = await _QueryHandler.Handle(filterQuery, token);

            //Assert
            var user = result.FirstOrDefault();

            Assert.NotNull(user);
            Assert.Equal(user.Name, expectedName);
            Assert.Equal(result.Count(), expectedCount);
        }

        private List<User> GetFakeUsers()
        {
            var dish = new Dish { Id = 1, Name = "Квашеная капуста" };
            var dish2 = new Dish { Id = 2, Name = "Бесквитный торт" };

            var user = new User(name: "Вася", SexType.Man, 35);
            user.AddDish(dish);

            var user2 = new User(name: "Ксюша", SexType.Woman, 35);
            user2.AddDish(dish2);

            var users = new List<User>() { user, user2 };
            return users;
        }
    }
}