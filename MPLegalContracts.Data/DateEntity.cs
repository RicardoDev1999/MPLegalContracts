namespace MPLegalContracts.Data
{
    // This is a common entity that will be used in the MPLegalContracts.Data namespace.
    public abstract class DateEntity
    {
        public virtual DateTimeOffset CreatedAt { get; set; } 
        public virtual DateTimeOffset? UpdatedAt { get; set; }
    };
}
