using Loto.Domain.Core;

namespace Loto.Domain.Entities.Transactions
{
    public class Recharge : BaseEntity
    {
        public string Id { get; set; }
        public string? Cia { get; set; }
        public string? Serial { get; set; }
        public string? Branch { get; set; }
        public string? Us { get; set; }
        public string? DateEnter { get; set; }

        public string? Provider { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Plan { get; set; }
        public decimal? Amount { get; set; }

        public string? Status { get; set; }
        public string? CollectDate { get; set; }
        public string? CollectUs { get; set; }
        public string? CollectId { get; set; }

    }
}
