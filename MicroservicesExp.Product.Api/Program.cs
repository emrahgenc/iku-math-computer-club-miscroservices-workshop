using System.Reflection;
using MicroservicesExp.Product.Api.Application.Queries;
using MicroservicesExp.Product.Api.Infrastructure.DbContexts;
using MicroservicesExp.Product.Api.Infrastructure.Profiles;
using MicroservicesExp.Product.Api.Infrastructure.Queries;
using MicroservicesExp.Product.Api.Infrastructure.Repositories;
using MicroservicesExp.Product.Api.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var migrationAssembly = typeof(ProductDbContext).GetTypeInfo().Assembly.GetName().Name;
builder.Services.AddDbContextPool<ProductDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"),
        a => { a.MigrationsAssembly(migrationAssembly); });
});
builder.Services.AddScoped<DbContext>(provider => provider.GetService<ProductDbContext>()!);

builder.Services.AddScoped<IProductUnitOfWork, ProductUnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IQuery<>), typeof(Query<>));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllProductsQuery).GetTypeInfo().Assembly));
builder.Services.AddAutoMapper(typeof(ProductProfile));

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    dbContext.Database.EnsureCreated();
}

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