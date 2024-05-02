
namespace MPLegalContracts.Data.LegalContracts
{
    // Here we could improve by making the Author an 1-n relationship with the legal contract,
    // where we have possible multiple authors for this contract.
    public sealed class LegalContractEntity : DateEntity
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
