using Gourmet.Domain;
using Gourmet.Infrastructure.Database;

namespace Gourmet.API.StartupTasks
{
    public class InitializeDefaultData
    {
        public static async Task Initialize(GourmetContext db)
        {
            if (db.Users.Any())
                return;

            await db.Dishes.AddRangeAsync(Dishes);
            await db.SaveChangesAsync();

            await db.Users.AddRangeAsync(Users);
            await db.SaveChangesAsync();

            // Устанавливаю любимые блюда
            var user = db.Users.FirstOrDefault(x => x.Name == _userIds[UserType.Vasya]);
            var dish = db.Dishes.FirstOrDefault(x => x.Name == _dishIds[DishType.Potato]);
            user.Dishes.Add(dish);

            user = db.Users.FirstOrDefault(x => x.Name == _userIds[UserType.Angela]);
            dish = db.Dishes.FirstOrDefault(x => x.Name == _dishIds[DishType.SoupKharcho]);
            user.Dishes.Add(dish);

            user = db.Users.FirstOrDefault(x => x.Name == _userIds[UserType.Lena]);
            dish = db.Dishes.FirstOrDefault(x => x.Name == _dishIds[DishType.AmateurCarp]);
            user.Dishes.Add(dish);

            user = db.Users.FirstOrDefault(x => x.Name == _userIds[UserType.Lev]);
            dish = db.Dishes.FirstOrDefault(x => x.Name == _dishIds[DishType.CaesarSalad]);
            user.Dishes.Add(dish);

            user = db.Users.FirstOrDefault(x => x.Name == _userIds[UserType.Pablo]);
            dish = db.Dishes.FirstOrDefault(x => x.Name == _dishIds[DishType.Shrimps]);
            user.Dishes.Add(dish);


            await db.SaveChangesAsync();
        }


        private enum UserType
        {
            Vasya,
            Angela,
            Lena,
            Lev,
            Pablo
        }
        private static Dictionary<UserType, string> _userIds = new Dictionary<UserType, string>()
            {
                { UserType.Vasya, "Вася" },
                { UserType.Angela, "Анжела" },
                { UserType.Lena, "Лена" },
                { UserType.Lev, "Лев" },
                { UserType.Pablo, "Пабло" },
            };
        private static IEnumerable<User> Users => new List<User>()
        {
            new()
            {
                //Id = 1,
                Name = "Вася",
                Sex = true,
                Age = 25,
            },
            new()
            {
                //Id = 2,
                Name = "Анжела",
                Sex = false,
                Age = 25
            },
            new()
            {
                //Id = 3,
                Name = "Лена",
                Sex = false,
                Age = 30
            },
            new()
            {
                //Id = 4,
                Name = "Лев",
                Sex = true,
                Age = 35
            },
            new()
            {
                //Id = 5,
                Name = "Пабло",
                Sex = true,
                Age = 40
            },
        };

        private enum DishType
        {
            Potato,
            SoupKharcho,
            AmateurCarp,
            CaesarSalad,
            Shrimps
        }
        private static Dictionary<DishType, string> _dishIds = new Dictionary<DishType, string>()
            {
                { DishType.Potato, "Картошка" },
                { DishType.SoupKharcho, "Суп харчо" },
                { DishType.AmateurCarp, "Карп любительский" },
                { DishType.CaesarSalad, "Салат Цезарь" },
                { DishType.Shrimps, "Креветки" },
            };

        private static IEnumerable<Dish> Dishes => new List<Dish>()
        {
            new()
            {
                //Id = 1,
                Name = "Картошка"
            },
            new()
            {
                //Id = 2,
                Name = "Суп харчо",
            },
            new()
            {
                //Id = 3,
                Name = "Карп любительский",
            },
            new()
            {
                //Id = 4,
                Name = "Салат Цезарь",
            },
            new()
            {
                //Id = 5,
                Name = "Креветки",
            },
        };
    }
}
