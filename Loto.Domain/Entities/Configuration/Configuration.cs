namespace Loto.Domain.Entities.Configuration
{
    public partial class Configuration
    {
        public short Id { get; set; }
        public string? Resource { get; set; }
        public string? Property { get; set; }
        public string? Value { get; set; }
    }
}