using Moq;
using Bogus;
using MPLegalContracts.Services.LegalContracts;
using MPLegalContracts.Data.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MPLegalContracts.Data.LegalContracts;
using MPLegalContracts.Services.Mappers;

public class ContractServiceTests
{
    private readonly ILegalContractServices _legalContractsServices;
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    private readonly Mock<TimeProvider> _timeProviderMock;

    private readonly Faker _faker;

    public ContractServiceTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _applicationDbContext = new ApplicationDbContext(options);

        _mapper = new MapperConfiguration(cfg => cfg.AddMaps(typeof(ApplicationMapperExtensions))).CreateMapper();
        _timeProviderMock = new Mock<TimeProvider>();
        _legalContractsServices = new LegalContractServices(_applicationDbContext, _mapper, _timeProviderMock.Object);

        _faker = new Faker();
    }

    [Fact]
    public async Task GetContractById_ReturnsContract_WhenContractExists()
    {
        // Arrange
        var contractId = 1;

        await _applicationDbContext.LegalContracts.AddAsync(new LegalContractEntity()
        {
            Id = contractId,
            Title = _faker.Lorem.Sentence(),
            Content = _faker.Lorem.Paragraphs(3),
            Author = _faker.Name.FullName(),
            CreatedAt = _faker.Date.Past(),
        });
        await _applicationDbContext.SaveChangesAsync();

        // Act
        var contract = await _legalContractsServices.GetLegalContractAsync(contractId);

        // Assert
        Assert.True(contract != null);
        Assert.True(contract.Id == contractId);
    }
}