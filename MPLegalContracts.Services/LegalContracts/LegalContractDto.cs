namespace MPLegalContracts.Services.LegalContracts
{
    public sealed class UpdateLegalContractDto
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    };

    public sealed class CreateLegalContractDto
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    };

    public sealed class LegalContractDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateDto DatePart { get; set; }
    };
}