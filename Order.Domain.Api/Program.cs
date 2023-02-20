using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Orders.Domain.Handlers;
using Orders.Domain.Infra.Contexts;
using Orders.Domain.Infra.Repositories;
using Orders.Domain.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));

builder.Services.AddTransient<ISellerRepository, SellerRepository>();
builder.Services.AddTransient<SellerHandler, SellerHandler>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ProductHandler, ProductHandler>();

builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<OrderHandler, OrderHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DocumentingSwagger.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Guilherme Lemke",
            Email = "email@email.com",
            Url = new Uri("https://teste.com.br")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyHeader());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
