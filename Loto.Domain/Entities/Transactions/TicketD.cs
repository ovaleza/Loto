using Loto.Domain.Core;

namespace Loto.Domain.Entities.Transactions
{
    public class TicketD : BaseEntity
    {
        public string Id { get; set; }
        public string? IdTicket { get; set; }
        public string? Cia { get; set; }
        public string? Branch { get; set; }
        public string? BranchB { get; set; }
        public string? Us { get; set; }
        public string? DateEnter { get; set; }
        public string? Numbers { get; set; }
        public decimal? Amount { get; set; }
        public string? Lottery { get; set; }
        public string? Mode { get; set; }
        public string? Winner { get; set; }
        public string? Prize { get; set; }
        public string? Status { get; set; }

    }
}
