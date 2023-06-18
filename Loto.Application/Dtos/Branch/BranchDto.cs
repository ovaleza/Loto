using System;
using System.Collections.Generic;
using System.Text;
using Loto.Domain.Entities.Branchs;

namespace Loto.Application.Dtos.Branch
{
    public class BranchDto : DtoBase
    {
        public int? Cia { get; set; }
        public int? Group { get; set; }
        public int? Zone { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? Collector { get; set; }
        public decimal? MaxLottery { get; set; }
        public decimal? MaxPhoneRecharge { get; set; }
        public decimal? MaxInvoices { get; set; }
        public string? Manager { get; set; }
        public string? Status { get; set; }
    }
}
