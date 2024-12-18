using Microsoft.EntityFrameworkCore;
using Tournament.Data;
using Tournament.Core.Services;
using Tournament.Data.Repository;
using Tournament.Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TournamentDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddScoped<ITournamentRepository,TournamentRepository>();
builder.Services.AddScoped<ITournamentService,TournamentService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
