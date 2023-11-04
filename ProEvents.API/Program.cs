using Event.API.Services;
using Event.API.Services.Impl;
using Microsoft.EntityFrameworkCore;
using ProEvents.Persistence;
using ProEvents.Persistence.Repositories;
using ProEvents.Persistence.Repositories.Impl;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors();
builder.Services.AddControllersWithViews()
        .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPartyService, PartyService>();
builder.Services.AddScoped<IPartiesRepository, PartiesRepository>();
builder.Services.AddScoped<IGenericRepository, GenericRepository>();

string connectionString = "server=localhost;port=3306;database=events;user=root;password=1234;SslMode=None;AllowPublicKeyRetrieval=True"; //builder.Configuration.GetConnectionString("Default");

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
