
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace gatherit;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<GatherItDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IJobAdRepository, JobAdRepository>();
        builder.Services.AddScoped<ICompanyNameRepository, CompanyNameRepository>();
        builder.Services.AddScoped<ICityRepository, CityRepository>();

        builder.Services.AddScoped<IDocumentSimilarityService, DocumentSimilarityService>();
        builder.Services.AddScoped<IComulator, Comulator>();

        builder.Services.AddHttpClient<IJustJoinItJobBoardHttpClient, JustJoinItJobBoardHttpClient>();


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
    }
}
