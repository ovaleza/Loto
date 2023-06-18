using Loto.Application.Dtos.Branch;
using Loto.Domain.Entities.Branchs;
using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Loto.Application.Extentions
{
    public static class BranchExtention
    {
        /// <summary>
        /// Se encarga de convertir de un DTO del Branch a su entidad
        /// </summary>
        /// <param name="branchDto">mi dto</param>
        /// <returns>Retorna el branch</returns>
        public static Branch ConvertDtoBranchToBranch(this BranchDto branchDto)
        {
            Branch branch = new Branch();
            Type bType = branch.GetType();
            Type dType = branchDto.GetType();
            PropertyInfo[] lst = dType.GetProperties();
            foreach (PropertyInfo pp in lst)
            {
                if (pp.Name!="IdUser" && pp.Name!="Date" && pp.Name!="BranchId")
                {
                    var que = pp.GetValue(branchDto);
                    bType.GetProperty(pp.Name).SetValue(branch, que, null);
                }
            };
            return branch;
        }
        public static Group ConvertDtoGroupToGroup(this GroupDto groupDto)
        {
            Group group = new Group();
            Type bType = group.GetType();
            Type dType = groupDto.GetType();
            PropertyInfo[] lst = dType.GetProperties();
            foreach (PropertyInfo pp in lst)
            {
                if (pp.Name != "IdUser" && pp.Name != "Date" && pp.Name != "GroupId")
                {
                    var que = pp.GetValue(groupDto);
                    bType.GetProperty(pp.Name).SetValue(group, que, null);
                }
            };
            return group;
        }
    }
}
