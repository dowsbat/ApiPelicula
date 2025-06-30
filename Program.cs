using ApiPelicula.DataAccess;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using ApiPelicula.Validators;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


builder.Services.AddValidatorsFromAssemblyContaining<Program>();// con colocar solo una validator de la carpeta validators es mas que suficiente para detectar toda
builder.Services.AddFluentValidationAutoValidation();



builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program)); // busca en todo en el ensamblado los profiles


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
