using AutoMapper;
using MPLegalContracts.Data.Context;
using MPLegalContracts.Data.LegalContracts;
using Microsoft.EntityFrameworkCore;

namespace MPLegalContracts.Services.LegalContracts
{
    public sealed class LegalContractServices : ILegalContractServices
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly TimeProvider _timeProvider;

        public LegalContractServices(ApplicationDbContext dbContext, IMapper mapper, TimeProvider timeProvider)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _timeProvider = timeProvider;
        }

        public async Task<LegalContractDto?> CreateLegalContractAsync(CreateLegalContractDto legalContract)
        {
            ArgumentNullException.ThrowIfNull(legalContract, nameof(legalContract));

            var legalContractEntity = _mapper.Map<CreateLegalContractDto, LegalContractEntity>(legalContract);
            legalContractEntity.CreatedAt = _timeProvider.GetUtcNow();

            await _dbContext.LegalContracts
                .AddAsync(legalContractEntity);

            var saveSucceeded = (await _dbContext.SaveChangesAsync()) > 0;

            return saveSucceeded
                ? _mapper.Map<LegalContractEntity, LegalContractDto>(legalContractEntity)
                : null;
        }

        public async Task<LegalContractDto?> GetLegalContractAsync(int id)
        {
            ArgumentNullException.ThrowIfNull(id, nameof(id));

            return await _dbContext.LegalContracts
                .Where(lc => lc.Id == id && !lc.IsDeleted)
                .Select(lc => _mapper.Map<LegalContractEntity, LegalContractDto>(lc))
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<LegalContractDto>> GetLegalContractsAsync()
        {
            return await _dbContext.LegalContracts
                .Where(lc => !lc.IsDeleted)
                .Select(lc => _mapper.Map<LegalContractEntity, LegalContractDto>(lc))
                .ToListAsync();
        }

        public async Task<LegalContractDto?> UpdateLegalContractAsync(UpdateLegalContractDto legalContract)
        {
            ArgumentNullException.ThrowIfNull(legalContract, nameof(legalContract));

            var legalContractEntity = await _dbContext.LegalContracts.FindAsync(legalContract.Id)
                ?? throw new ArgumentException($"Legal contract with id {legalContract.Id} not found");

            legalContractEntity.Author = legalContract.Author ?? legalContractEntity.Author;
            legalContractEntity.Title = legalContract.Title ?? legalContractEntity.Title;
            legalContractEntity.Content = legalContract.Content ?? legalContractEntity.Content;
            legalContractEntity.UpdatedAt = _timeProvider.GetUtcNow();

            _dbContext.LegalContracts.Update(legalContractEntity);

            var saveSucceeded = (await _dbContext.SaveChangesAsync()) > 0;

            return saveSucceeded 
                ? _mapper.Map<LegalContractEntity, LegalContractDto>(legalContractEntity) 
                : null;
        }

        public async Task<bool> DeleteLegalContractAsync(int id)
        {
            ArgumentNullException.ThrowIfNull(id, nameof(id));

            var legalContractEntity = await _dbContext.LegalContracts.FindAsync(id)
                ?? throw new ArgumentException($"Legal contract with id {id} not found");

            legalContractEntity.IsDeleted = true;
            legalContractEntity.UpdatedAt = _timeProvider.GetUtcNow();

            _dbContext.LegalContracts.Update(legalContractEntity);

            var saveSucceeded = (await _dbContext.SaveChangesAsync()) > 0;

            return saveSucceeded;
        }
    }
}
