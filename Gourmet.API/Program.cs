using Gourmet.API.StartupTasks;
using Gourmet.Infrastructure.Database;
using Gourmet.Application.Commands;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Gourmet.Domain.Repositories;
using Gourmet.Infrastructure.RepositoriesCommands;

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

// ��
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<GourmetContext>(opt => opt.UseSqlServer(connection));
//builder.Services.AddDbContext<GourmetContext>(options => options.UseSqlServer(connection));
// ������������� ��.
builder.Services.AddHostedService<DatabaseInitialization>();

// �������� ���� ����������� � ���� �������.
var assemblies = new Assembly[]
{
    typeof(Program).GetTypeInfo().Assembly,
    typeof(CreateUserCommand).GetTypeInfo().Assembly,
};
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

// Repositories commands.
builder.Services.AddScoped<IUserCommandsRepository, UserCommandsRepository>();


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
