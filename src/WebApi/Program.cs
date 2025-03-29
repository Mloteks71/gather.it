using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var postgresConnectionString = DatabaseConfigHelper.GetPostgresConnectionString(configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GatherItDbContext>(options =>
    options.UseNpgsql(postgresConnectionString, 
        optionsBuilder => optionsBuilder.MigrationsAssembly("Domain")));

builder.Services.AddScoped<IJobAdRepository, JobAdRepository>();
builder.Services.AddScoped<ICompanyNameRepository, CompanyNameRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddScoped<IDocumentSimilarityService, DocumentSimilarityService>();
builder.Services.AddScoped<IComulator, Comulator>();

builder.Services.AddHttpClient<IJustJoinItJobBoardHttpClient, JustJoinItJobBoardHttpClient>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await using (var serviceScope = app.Services.CreateAsyncScope())
    using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<GatherItDbContext>())
    {
        dbContext.Database.Migrate();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
