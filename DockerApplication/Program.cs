using DockerApplication.DAL;
using DockerApplication.Services;
using Microsoft.EntityFrameworkCore;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<CustomerService>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("Development"));
        });
        builder.Services.AddControllers();
        builder.Services.AddScoped<ICustomerServices, CustomerServices>();

        var app = builder.Build();
        app.MapControllers();
        app.Run();
    }
}