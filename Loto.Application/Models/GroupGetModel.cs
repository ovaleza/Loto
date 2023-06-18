using System;
using System.Collections.Generic;
using System.Text;

namespace Loto.Application.Models
{
    public class GroupGetModel
    {
        public int? Id { get; set; }
        public string? Cia { get; set; }
        public string? Name { get; set; }
        public string? UserMaster { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? SaleYes { get; set; }
        public string? SaleLimiter { get; set; }
        public string? SaleMax { get; set; }
        public string? PlanType { get; set; }
        public string? Status { get; set; }
    }
}
