using Loto.Domain.Entities.Security;
using Loto.Domain.Repository;
using Loto.Infrastructure.Models.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loto.Infrastructure.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<List<UsuarioModel>> GetUsuarios();
        Task<UsuarioModel> GetUsuario(string email, string pwd);
    }
}
