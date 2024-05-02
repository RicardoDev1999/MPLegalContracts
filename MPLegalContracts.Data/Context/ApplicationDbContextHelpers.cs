using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MPLegalContracts.Data.Context;
using MPLegalContracts.Data.LegalContracts;

public static class ApplicationDbContextHelpers
{

    public static IServiceCollection ConfigureSqlDatabaseApplicationDbContext(this IServiceCollection services, string databaseConnString)
    {
        return services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(databaseConnString));
    }

    public static IServiceCollection ConfigureInMemoryApplicationDbContext(this IServiceCollection services, 
        string inMemoryDbName = "MPLegalContracts")
    {
        return services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase(inMemoryDbName));
    }

    public static ModelBuilder ConfigureLegalContractEntity(this ModelBuilder modelBuilder)
    {
        var legalContractEntity = modelBuilder.Entity<LegalContractEntity>();

        legalContractEntity
            .HasKey(legalContract => legalContract.Id);

        legalContractEntity
            .Property(legalContract => legalContract.Id)
            .UseIdentityColumn();

        legalContractEntity
            .ToTable("LegalContracts");

        legalContractEntity
            .HasData(
                new LegalContractEntity
                {
                    Id = 1,
                    Author = "Author 1",
                    Title = "Legal Contract 1",
                    Content = "This is a legal contract",
                    CreatedAt = DateTime.Now
                },
                new LegalContractEntity
                {
                    Id = 2,
                    Author = "Author 2",
                    Title = "Legal Contract 2",
                    Content = "This is a legal contract",
                    CreatedAt = DateTime.Now
                },
                new LegalContractEntity
                {
                    Id = 3,
                    Author = "Author 3",
                    Title = "Legal Contract 3",
                    Content = "This is a legal contract",
                    CreatedAt = DateTime.Now
                }
            );

        return modelBuilder;
    }
}