using MPLegalContracts.Services.LegalContracts;

internal static class GetLegalContracts
{
    public static async Task<ICollection<LegalContractDto>> ExecuteAsync(ILegalContractServices legalContractsServices)
    {
        return await legalContractsServices.GetLegalContractsAsync();
    }
}