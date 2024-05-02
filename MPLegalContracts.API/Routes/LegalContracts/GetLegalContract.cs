using MPLegalContracts.Services.LegalContracts;

namespace MPLegalContracts.API.Routes.LegalContracts
{
    public static class GetLegalContract
    {
        public static async Task<LegalContractDto?> ExecuteAsync(ILegalContractServices legalContractsServices, int id)
        {
            return await legalContractsServices.GetLegalContractAsync(id);
        }

    }
}
