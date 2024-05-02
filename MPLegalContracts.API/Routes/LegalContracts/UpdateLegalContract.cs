using MPLegalContracts.Services.LegalContracts;

namespace MPLegalContracts.API.Routes.LegalContracts
{
    public static class UpdateLegalContract
    {
        public static async Task<LegalContractDto?> ExecuteAsync(ILegalContractServices legalContractsServices, UpdateLegalContractDto model)
        {
            return await legalContractsServices.UpdateLegalContractAsync(model);
        }
    }
}
