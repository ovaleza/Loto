using Loto.Application.Models;
using Loto.Web.Models.Branchs;

namespace Loto.Web.Models.Responses
{
    public class BranchListResponse : ResponseBase
    {
        public List<BranchModel>? data { get; set; }
     }
    public class BranchGetResponse : ResponseBase
    {
        public Branch? data { get; set; }
    }
}

