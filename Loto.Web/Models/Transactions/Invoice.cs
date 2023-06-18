namespace Loto.Web.Models.Transactions
{
    public class Invoice
    {
        public string Id { get; set; }
        public string? Cia { get; set; }
        public string? Type { get; set; }
        public string? Serial { get; set; }
        public string? Branch { get; set; }
        public string? Us { get; set; }
        public string? DateEnter { get; set; }

        public string? Client { get; set; }
        public string? Reference { get; set; }
        public string? Amount { get; set; }
        public string? Winner { get; set; }
        public string? Provider { get; set; }

        public string? Status { get; set; }
        public string? CollectDate { get; set; }
        public string? CollectUs { get; set; }
        public string? CollectId { get; set; }
    }
}
