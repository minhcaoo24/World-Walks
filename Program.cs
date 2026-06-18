using Microsoft.EntityFrameworkCore;
using WorldWalks.Data;
using WorldWalks.Repositories.DifficultyRepository;
using WorldWalks.Repositories.RegionRepository;
using WorldWalks.Repositories.WalkRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<WorldWalksDbContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration.GetConnectionString("WorldWalksConnectionString"));
});

//Add Repository Pattern
builder.Services.AddScoped<IRegionRepository, SqlRegionRepository>();
builder.Services.AddScoped<IWalkRepository, SqlWalkRepository>();
builder.Services.AddScoped<IDifficultyRepository, SqlDifficultyRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();