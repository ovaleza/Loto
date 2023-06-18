using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Loto.Application.Contract;
using Loto.Application.Core;
using Loto.Application.Dtos.Usuario;
using Loto.Domain.Entities.Security;
using Loto.Infrastructure.Core;
using Loto.Infrastructure.Interfaces;


namespace Loto.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ILogger<UsuarioService> logger;

        public UsuarioService(IUsuarioRepository usuarioRepository, ILogger<UsuarioService> logger)
        {
            this.usuarioRepository = usuarioRepository;
            this.logger = logger;
        }

        public async Task<ServiceResult> GetUsuario(GetUsuarioInfoDto getUsuarioInfoDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await this.usuarioRepository
                                        .GetUsuario(getUsuarioInfoDto.Email, 
                                                    getUsuarioInfoDto.Password);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo la información del usuario.";
                this.logger.LogError($"{ result.Message }  { ex.Message}", ex.ToString());
            }


            return result;
        }

        public async Task<ServiceResult> SaveUsuario(UsaurioAddDto productAddDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Usuario usuario = new Usuario()
                {
                    Email = productAddDto.Email,
                    Name = productAddDto.Name,
                    Password = Encript.GetSHA512(productAddDto.Password),
                    IdRol = productAddDto.IdRol,
                    NameFoto = productAddDto.NameFoto,
                    IdUserCreated = productAddDto.IdUser,
                    Phone = productAddDto.Phone,
                    UrlFoto = productAddDto.UrlFoto
                };

                await this.usuarioRepository.Save(usuario);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el usuario: ";
                this.logger.LogError($"{result.Message} {ex.Message}", ex.ToString());

            }

            return result;
        }
       
    }
}
