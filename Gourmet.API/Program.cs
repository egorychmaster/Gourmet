using Gourmet.API.StartupTasks;
using Gourmet.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Gourmet.Domain.Repositories;
using Gourmet.Infrastructure.RepositoriesCommands;
using Gourmet.Application.Commands.Users;
using Gourmet.Infrastructure.RepositoriesQueries;
using Gourmet.Application.Queries.Favorites;
using Gourmet.Application.Queries.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(option =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    option.IncludeXmlComments(xmlPath);
});

// БД
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<GourmetContext>(opt => opt.UseSqlServer(connection));
//builder.Services.AddDbContext<GourmetContext>(options => options.UseSqlServer(connection));
// Инициализация БД.
builder.Services.AddHostedService<DatabaseInitialization>();

// Медиатор ищет обработчики в этих сборках.
var assemblies = new Assembly[]
{
    typeof(Program).GetTypeInfo().Assembly,
    typeof(CreateUserCommand).GetTypeInfo().Assembly,
};
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

// Repositories commands.
builder.Services.AddScoped<IUserCommandsRepository, UserCommandsRepository>();
builder.Services.AddScoped<IDishCommandsRepository, DishCommandsRepository>();

// Repositories queries.
builder.Services.AddScoped<IFavoriteQueriesRepository, FavoriteQueriesRepository>();
builder.Services.AddScoped<IUserQueriesRepository, UserQueriesRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
