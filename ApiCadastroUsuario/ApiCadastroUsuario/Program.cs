using Infra.Data;
using IOC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<DbContext, AppDbContext>();

builder.Services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CadastroDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False").EnableSensitiveDataLogging());


InversionControl.RegistrarServicos(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*Adicionando polita de cors para que a requisição chegue ao BACK*/
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy( policy =>
    {
        policy.WithOrigins("http://localhost:5500").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});



var app = builder.Build();

app.UseCors();

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
