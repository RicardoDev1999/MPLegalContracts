
namespace MPLegalContracts.Services.LegalContracts
{
    public interface ILegalContractServices
    {
        Task<LegalContractDto?> CreateLegalContractAsync(CreateLegalContractDto legalContract);
        Task<bool> DeleteLegalContractAsync(int id);
        Task<LegalContractDto?> GetLegalContractAsync(int id);
        Task<ICollection<LegalContractDto>> GetLegalContractsAsync();
        Task<LegalContractDto?> UpdateLegalContractAsync(UpdateLegalContractDto legalContract);
    }
}