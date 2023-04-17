using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAppDeleite.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();

        var CnnStrBuilder = new SqlConnectionStringBuilder(
            builder.Configuration.GetConnectionString("CNNSTR"));

        string cnnStr = CnnStrBuilder.ConnectionString;
        builder.Services.AddDbContext<DeleiteContext>(options => options.UseSqlServer(cnnStr));

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseRouting();
        
        app.UseAuthentication();

        app.MapControllers();

        app.Run();


    }


}