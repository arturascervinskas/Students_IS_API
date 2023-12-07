
using Npgsql;
using Serilog;
using Students_IS_API.Interfaces;
using Students_IS_API.Repositories;
using Students_IS_API.Services;
using System.Data;

namespace Students_IS_API
{
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
            builder.Services.AddTransient<IDbConnection>((sp) => new NpgsqlConnection(builder.Configuration.GetConnectionString("connection")));
            builder.Services.AddTransient<ICoursesService, CoursesService>();
            builder.Services.AddTransient<IStudentService, StudentService>();
            builder.Services.AddTransient<IDepartmentService, DepartmentService>();
            builder.Services.AddTransient<ICoursesRepository, CoursesRepository>();
            builder.Services.AddTransient<IStudentRepository, StudentRepository>();
            builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
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
