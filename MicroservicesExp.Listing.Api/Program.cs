using System.Reflection;
using MassTransit;
using MicroservicesExp.Listing.Api.Application.Queries;
using MicroservicesExp.Listing.Api.Infrastructure.DbContexts;
using MicroservicesExp.Listing.Api.Infrastructure.Profiles;
using MicroservicesExp.Listing.Api.Infrastructure.Queries;
using MicroservicesExp.Listing.Api.Infrastructure.Repositories;
using MicroservicesExp.Listing.Infrastructure.Queries;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var mongoConnectionString = builder.Configuration.GetConnectionString("DbConnection");
var mongoClientSettings = MongoClientSettings.FromConnectionString(mongoConnectionString);

builder.Services.AddSingleton(mongoClientSettings);
builder.Services.AddScoped<ListingDbContext>();

builder.Services.AddScoped<IListingRepository, ListingRepository>();
builder.Services.AddScoped<IQuery, Query>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllListingsQuery).GetTypeInfo().Assembly));
builder.Services.AddAutoMapper(typeof(ListingProfile));

builder.Services.AddMassTransit(m=>
{
    m.AddConsumers(Assembly.GetExecutingAssembly());
    m.UsingRabbitMq((ctx,cfg)=>
    {
        cfg.Host("host.docker.internal", 35672, "/", c =>
        {
            c.Username("sa");
            c.Password("Sa123456");
        });
        cfg.ConfigureEndpoints(ctx);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();