using Loto.Domain.Core;

namespace Loto.Domain.Entities.Transactions
{
    public class Ticket : BaseEntity
    {
        public string Id { get; set; }
        public string? Cia { get; set; }
        public string? Serial { get; set; }
        public string? Branch { get; set; }
        public string? Us { get; set; }
        public string? Vendor { get; set; }
        public string? DateEnter { get; set; }

        public string? Client { get; set; }
        public decimal? Amount { get; set; }
        public string? Winner { get; set; }
        public string? Prize { get; set; }
        public string? PayPrizeId { get; set; }

        public string? Status { get; set; }
        public string? CollectDate { get; set; }
        public string? CollectUs { get; set; }
        public string? CollectId { get; set; }
        public string? Lines { get; set; }
    }
}
