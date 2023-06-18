namespace Loto.Domain.Entities.Configuration
{
    public partial class Bussines : Core.BaseEntity
    {
        public int Id { get; set; }
        public string? UrlLogo { get; set; }
        public string? NameLogo { get; set; }
        public string? Document { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public decimal? TaxPercent { get; set; }
        public string? Currency { get; set; }

    }
}