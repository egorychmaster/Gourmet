using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gourmet.Infrastructure.Database
{
    /// <summary>
    /// Фабрика времени разработки (для миграции Service2Context).
    /// https://stackoverflow.com/questions/60561851/an-error-occurred-while-accessing-the-microsoft-extensions-hosting-services-when
    /// https://learn.microsoft.com/ru-ru/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli
    /// 
    /// 1. Сделать стартовый проект к запуску по умолчанию.
    /// 2. В Package Manager Console выбрать проект Infrastructure и выполнить команду:
    /// Add-Migration InitialCreate -context GourmetContext -o Database/Migrations
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GourmetContext>
    {
        public GourmetContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GourmetContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Gourmet;");

            return new GourmetContext(optionsBuilder.Options);
        }
    }
}
