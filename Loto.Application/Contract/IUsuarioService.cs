using Loto.Application.Core;
using Loto.Application.Dtos.Branch;
using Loto.Application.Dtos.Usuario;
using Loto.Application.Responses;
using System.Threading.Tasks;

namespace Loto.Application.Contract
{
    public interface IUsuarioService
    {
        Task<ServiceResult> SaveUsuario(UsaurioAddDto productAddDto);

        Task<ServiceResult> GetUsuario(GetUsuarioInfoDto getUsuarioInfoDto); 
         

    }
}
