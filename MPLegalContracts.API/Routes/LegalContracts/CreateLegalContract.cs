using MPLegalContracts.Services.LegalContracts;

namespace MPLegalContracts.API.Routes.LegalContracts
{
    public static class CreateLegalContract
    {
        public static async Task<LegalContractDto?> ExecuteAsync(ILegalContractServices legalContractsServices, CreateLegalContractDto model)
        {
            return await legalContractsServices.CreateLegalContractAsync(model);
        }
    }
}
