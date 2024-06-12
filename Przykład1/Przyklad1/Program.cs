using Microsoft.EntityFrameworkCore;
using Przyklad1.Context;
using Przyklad1.Endpoints;
using Przyklad1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<DataBaseContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
var baseEndpointsGroup = app.MapGroup("api");
baseEndpointsGroup.RegisterAccountEndpoints();
baseEndpointsGroup.RegisterProductEndpoints();

app.Run();