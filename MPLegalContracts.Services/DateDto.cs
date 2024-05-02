namespace MPLegalContracts.Services
{
    // This is a common entity that will be used in the MPLegalContracts Services / Application Layers.
    public record DateDto(DateTimeOffset CreatedAt, DateTimeOffset? UpdatedAt);
}
