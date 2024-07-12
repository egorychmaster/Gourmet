using Gourmet.API.StartupTasks;
using Gourmet.Infrastructure.Database;
using Gourmet.Application.Commands;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    typeof(UserCreateOrUpdateCommand).GetTypeInfo().Assembly,
};
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));


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
