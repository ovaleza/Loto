using Loto.Application.Core;
using Loto.Application.Dtos.Branch;
using Loto.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loto.Application.Contract
{
    public interface IGroupService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<AddResponse> Save(GroupDto entity);
        Task<ServiceResult> Update(GroupDto entity);
        Task<ServiceResult> Delete(int id);
        //Task<ServiceResult> GetBranchGroupDetail(int IdBranch);
        //Task<ServiceResult> GetBranchesByGroup(int IdGroup);

    }
}
