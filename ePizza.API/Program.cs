
using ePizza.Core.Concrete;
using ePizza.Core.Contracts;
using ePizza.Domain.Models;
using ePizza.Repository.Concrete;
using ePizza.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ePizza.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ePizzaHubDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
           // builder.Services.AddAutoMapper(typeof(MappingProfile));

            // builder.Services.AddTransient<IUserService,EmployeeService>();
            builder.Services.AddScoped<IUserService,UserService>(); //Registering the service dependencies
            builder.Services.AddScoped<IUserRepository, UserRepository>();

           
            builder.Services.AddScoped<IitemService,ItemService>();
            builder.Services.AddScoped<IItemRepository,ItemRepository>();

            builder.Services.AddScoped<IRolesRepository, RolesRepository>();
           // builder.Services.AddScoped<IRolesService, RolesService>();

            builder.Services.AddScoped<IAuthService, AuthService>();
            
           

            

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
}
