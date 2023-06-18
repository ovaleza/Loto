using Loto.Domain.Core;
using System;

namespace Loto.Domain.Entities.Transactions
{
    public class Invoice : BaseEntity
    {
        public int Id { get; set; }
        public int? Cia { get; set; }
        public string? Type { get; set; }
        public string? Serial { get; set; }
        public int? Branch { get; set; }
        public string? Us { get; set; }
        public DateTime? DateEnter { get; set; }

        public string? Client { get; set; }
        public string? Reference { get; set; }
        public decimal? Amount { get; set; }
        public bool? Winner { get; set; }
        public int? Provider { get; set; }

        public string? Status { get; set; }
        public DateTime? CollectDate { get; set; }
        public int? CollectUs { get; set; }
        public int? CollectId { get; set; }
    }
}
