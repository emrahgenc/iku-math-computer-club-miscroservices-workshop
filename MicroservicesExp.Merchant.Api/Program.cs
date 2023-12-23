using System.Reflection;
using MassTransit;
using MicroservicesExp.Merchant.Application.Queries;
using MicroservicesExp.Merchant.Infrastructure.DbContexts;
using MicroservicesExp.Merchant.Infrastructure.Profiles;
using MicroservicesExp.Merchant.Infrastructure.Queries;
using MicroservicesExp.Merchant.Infrastructure.Repositories;
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
builder.Services.AddScoped<MerchantDbContext>();

builder.Services.AddScoped<IMerchantRepository, MerchantRepository>();
builder.Services.AddScoped<IQuery, Query>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllMerchantsQuery).GetTypeInfo().Assembly));
builder.Services.AddAutoMapper(typeof(MerchantProfile));

builder.Services.AddMassTransit(m=>
{
    m.AddConsumers(Assembly.GetExecutingAssembly());
    m.UsingRabbitMq((ctx,cfg)=>
    {
        cfg.Host("host.docker.internal", 35672,"/",c=>
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