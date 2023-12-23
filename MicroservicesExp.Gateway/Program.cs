using MicroservicesExp.Gateway.ApiClients;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOcelot();
builder.Services.AddSwaggerForOcelot(builder.Configuration);

builder.Services.AddRefitClient<IListingApiClient>()
    .ConfigureHttpClient(client => { client.BaseAddress = new Uri("http://host.docker.internal:5010"); })
    .AddRetryPolicy()
    .AddTimeoutPolicy(2)
    .AddCircuitBreakerPolicy();

builder.Services.AddRefitClient<IMerchantApiClient>()
    .ConfigureHttpClient(client => { client.BaseAddress = new Uri("http://host.docker.internal:5011"); });

builder.Services.AddRefitClient<IProductApiClient>()
    .ConfigureHttpClient(client => { client.BaseAddress = new Uri("http://host.docker.internal:5012"); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
   // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseOcelot();

app.Run();