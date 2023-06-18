using Loto.Application.Contract;
using Loto.Application.Core;
using Loto.Application.Responses;
using Loto.Infrastructure.Interfaces;
using Loto.Domain.Entities.Branchs;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Loto.Application.Extentions;
using Loto.Application.Dtos.Branch;
using System.Reflection;

namespace Loto.Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository groupRepository;
        private readonly ILogger<GroupService> logger;

        public GroupService(IGroupRepository groupRepository,
            ILogger<GroupService> logger)
        {
            this.groupRepository = groupRepository;
            this.logger = logger;
        }
        public async Task<ServiceResult> Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await this.groupRepository.GetAll();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los Grupos";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }
            return result;
        }

        public async Task<ServiceResult> GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await this.groupRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el Grupo";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return result;
        }

        public async Task<ServiceResult> Update(GroupDto groupDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                if (string.IsNullOrEmpty(groupDto.Name))
                {
                    result.Message = "Nombre es requerido";
                    result.Success = false;
                    return result;
                }

                if (groupDto.Name.Length > 50)
                {
                    result.Message = "Logitud inválida";
                    result.Success = false;
                    return result;
                }

                Group group = await this.groupRepository.GetById(groupDto.Id);

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
                group.DateModified = DateTime.Now;
                group.IdUserModified = 99;
                await this.groupRepository.Update(group);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error modificando el grupo";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return result;
        }

        public async Task<AddResponse> Save(GroupDto groupDto)
        {
            AddResponse addResponse= new AddResponse();
            try
            {
                if (string.IsNullOrEmpty(groupDto.Name))
                {
                    addResponse.Message = "Nombre es requerido";
                    addResponse.Success = false;
                    return addResponse;
                }

                if (groupDto.Name.Length > 50)
                {
                    addResponse.Message = "Logitud inválidad";
                    addResponse.Success = false;
                    return addResponse;
                }

                Group group = groupDto.ConvertDtoGroupToGroup();

                await this.groupRepository.Save(group);

                addResponse.Id = group.Id;


            }
            catch (Exception ex)
            {
                addResponse.Success = false;
                addResponse.Message = "Error agregando el grupo";
                this.logger.Log(LogLevel.Error, $" {addResponse.Message}", ex.ToString());
            }
            return addResponse;
        }
        public async Task<ServiceResult> Delete(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Group item = await this.groupRepository.GetById(id);
                item.IsDeleted = true;
                item.DateDeleted = DateTime.Now;
                item.IdUserDeleted = 99;
                await this.groupRepository.Update(item);
                
                //await groupRepository.Delete(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el Group";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }
            return result;
        }

    }
}
