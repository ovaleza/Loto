using Loto.Domain.Core;

namespace Loto.Domain.Entities.Branchs
{
    public class Group : BaseEntity
    {
        public int Id { get; set; }
        public int? Cia { get; set; }
        public string? Name { get; set; }
        public string? UserMaster { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool? SaleYes { get; set; }
        public bool? SaleLimiter { get; set; }
        public decimal? SaleMax { get; set; }
        public int? PlanType { get; set; }
        public string? Status { get; set; }
    }
}
