using Loto.Web.Models;
using Loto.Web.Models.Requests;
using Loto.Web.Models.Responses;

namespace Loto.Web.ApiServices.Interfaces
{
    public interface IBranchApiService
    {
        Task<BranchListResponse> GetBranchList();
        Task<BranchGetResponse> GetBranch(int id);
        Task<BranchAddResponse> SaveBranch(BranchSaveRequest branch);
        Task<ResponseBase> UpdateBranch(BranchSaveRequest branch);



    }
}
