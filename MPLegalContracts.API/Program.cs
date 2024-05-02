using MPLegalContracts.API.Routes.LegalContracts;
using MPLegalContracts.Data.Context;
using MPLegalContracts.Services;

namespace MPLegalContracts.API
{
    public class Program
    {
        public static void Main(string[] args)
       {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton(TimeProvider.System);

            builder.Services.ConfigureApplicationServices();

            var databaseConnString = builder.Configuration.GetConnectionString("Database");

            if (databaseConnString != null)
            {
                builder.Services.ConfigureSqlDatabaseApplicationDbContext(databaseConnString);
            }
            else
            {
                builder.Services.ConfigureInMemoryApplicationDbContext();
            }

            var app = builder.Build();

            //Ensure the database is created. (In-memory database)
            app.Services.CreateScope().ServiceProvider
                .GetRequiredService<ApplicationDbContext>()
                .Database.EnsureCreated();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors(c =>
                {
                    c.WithMethods("GET", "POST", "PUT", "DELETE");
                    c.AllowAnyHeader();
                    c.AllowAnyOrigin();
                });
            }
            else
            {
                // Configure origin and headers for staging / production
                app.UseCors(c =>
                {
                    c.WithMethods("GET", "POST", "PUT", "DELETE");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Add routes for the application here.
            app.MapLegalContractRoutes();

            app.Run();
        }
    }
}
