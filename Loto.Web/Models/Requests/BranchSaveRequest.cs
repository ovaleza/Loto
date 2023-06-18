using Microsoft.AspNetCore.Identity;

namespace Loto.Web.Models.Requests
{
    public class BranchSaveRequest
    {
        public int id { get; set; }
        public int? idUser { get; set; }
        public DateTime? date { get; set; }
        public int cia { get; set; }
        public int? group { get; set; }
        public int? zone { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        public string? address { get; set; }
        public string? phone { get; set; }
        public int? collector { get; set; }
        public decimal? maxLottery { get; set; }
        public decimal? maxPhoneRecharge { get; set; }
        public decimal? maxInvoices { get; set; }
        public string? manager { get; set; }
        public string? status { get; set; }
    }
}
