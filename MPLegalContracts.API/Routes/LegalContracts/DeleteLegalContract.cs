using MPLegalContracts.Services.LegalContracts;

namespace MPLegalContracts.API.Routes.LegalContracts
{
    public static class DeleteLegalContract
    {
        public static async Task<bool> ExecuteAsync(ILegalContractServices legalContractsServices, int id)
        {
            return await legalContractsServices.DeleteLegalContractAsync(id);
        }
    }
}
