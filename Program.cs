using Event.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors();
builder.Services.AddControllersWithViews()
        .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = "server=localhost;port=3306;database=events;user=root;password=1234;SslMode=None"; //builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<DataContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(cors => cors.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin());

app.MapControllers();

app.Run();
