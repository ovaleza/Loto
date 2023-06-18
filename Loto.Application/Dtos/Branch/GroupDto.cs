using System;
using System.Collections.Generic;
using System.Text;

namespace Loto.Application.Dtos.Branch
{
    public class GroupDto : DtoBase
    {
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
