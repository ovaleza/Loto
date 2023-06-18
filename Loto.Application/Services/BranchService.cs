using Loto.Application.Contract;
using Loto.Application.Core;
using Loto.Application.Responses;
using Loto.Infrastructure.Interfaces;
using Loto.Domain.Entities.Branchs;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Loto.Application.Extentions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Loto.Application.Dtos.Branch;

namespace Loto.Application.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository branchRepository;
        private readonly IGroupRepository groupRepository;
        private readonly ILogger<BranchService> logger;

        public BranchService(IBranchRepository branchRepository,
            IGroupRepository groupRepository,
            ILogger<BranchService> logger)
        {
            this.branchRepository = branchRepository;
            this.groupRepository = groupRepository;
            this.logger = logger;
        }
        public async Task<ServiceResult> Get()
        {
            //List<Models.BranchGetModel> list = new List<Models.BranchGetModel>();

            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await getBranches();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los Branches";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }
            return result;
        }

        public async Task<ServiceResult> GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = (await getBranches(Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el Branch";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return result;
        }

        public async Task<ServiceResult> Update(BranchDto branchDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                if (string.IsNullOrEmpty(branchDto.Name))
                {
                    result.Message = "Nombre es requerido";
                    result.Success = false;
                    return result;
                }

                if (branchDto.Name.Length > 50)
                {
                    result.Message = "Logitud inválidad";
                    result.Success = false;
                    return result;
                }


                Branch branch = await this.branchRepository.GetById(branchDto.Id);

                Type bType = branch.GetType();
                Type dType = branchDto.GetType();
                PropertyInfo[] lst = dType.GetProperties();
                foreach (PropertyInfo pp in lst)
                {
                    if (pp.Name != "IdUser" && pp.Name != "Date" && pp.Name != "BranchId")
                    {
                        var que = pp.GetValue(branchDto);
                        bType.GetProperty(pp.Name).SetValue(branch, que, null);
                    }
                };
                branch.DateModified = DateTime.Now;
                branch.IdUserModified = 99;
                await this.branchRepository.Update(branch);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error modificando el Elemento";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return result;
        }

        public async Task<AddResponse> Save(BranchDto branchDto)
        {
            AddResponse addResponse= new AddResponse();
            try
            {
                if (string.IsNullOrEmpty(branchDto.Name))
                {
                    addResponse.Message = "Nombre es requerido";
                    addResponse.Success = false;
                    return addResponse;
                }

                if (branchDto.Name.Length > 50)
                {
                    addResponse.Message = "Logitud inválidad";
                    addResponse.Success = false;
                    return addResponse;
                }

                Branch branch = branchDto.ConvertDtoBranchToBranch();

                await this.branchRepository.Save(branch);

                addResponse.Id = branch.Id;


            }
            catch (Exception ex)
            {
                addResponse.Success = false;
                addResponse.Message = "Error agregando el Elemento";
                this.logger.Log(LogLevel.Error, $" {addResponse.Message}", ex.ToString());
            }
            return addResponse;
        }
        public async Task<ServiceResult> Delete(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Branch item = await this.branchRepository.GetById(id);
                item.IsDeleted = true;
                item.DateDeleted = DateTime.Now;
                item.IdUserDeleted = 99;
                await this.branchRepository.Update(item);

                //await branchRepository.Delete(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el Branch";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }
            return result;
        }

        private async Task<List<Models.BranchGetModel>> getBranches(int? Id = null)
        {
            List<Models.BranchGetModel> list = new List<Models.BranchGetModel>();

            try
            {

                list = (from item in (await this.branchRepository.GetAll())
                            where item.Id == Id || !Id.HasValue
                            select new Models.BranchGetModel()
                            {
                                Id = item.Id,
                                Cia=item.Cia,
                                Group = item.Group,
                                Zone = item.Zone,
                                Code = item.Code,
                                Name = item.Name,
                                Address = item.Address,
                                Phone = item.Phone,
                                Collector = item.Collector,
                                MaxLottery  = item.MaxLottery,
                                MaxPhoneRecharge    = item.MaxPhoneRecharge,
                                MaxInvoices = item.MaxInvoices,
                                Manager = item.Manager,
                                Status = item.Status,
                            }).ToList();
            }
            catch (Exception ex)
            {
                list = null;
                this.logger.Log(LogLevel.Error, "Error obteniendo los Branchs", ex.ToString());
            }

            return list;
        }
    }
}
