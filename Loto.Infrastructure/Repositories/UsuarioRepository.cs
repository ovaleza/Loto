using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Loto.Domain.Entities.Security;
using Loto.Infrastructure.Context;
using Loto.Infrastructure.Core;
using Loto.Infrastructure.Interfaces;
using Loto.Infrastructure.Models.Usuario;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Loto.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly LotoContext context;
        private readonly ILogger<UsuarioRepository> logger;

        public UsuarioRepository(LotoContext context, ILogger<UsuarioRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<UsuarioModel> GetUsuario(string email, string pwd)
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            try
            {
                Usuario usuario = await this.context.Usuario.SingleOrDefaultAsync(us => us.Email == email
                                          && us.Password == Encript.GetSHA512(pwd));

                usuarioModel = new UsuarioModel()
                {
                    Email = usuario.Email,
                    Id = usuario.Id,
                    IdRol = usuario.IdRol,
                    Name = usuario.Name,
                    NameFoto = usuario.NameFoto,
                    Phone = usuario.Phone,
                    UrlFoto = usuario.UrlFoto
                };

            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo el usuario.", ex.Message);
            }

            return usuarioModel;
        }

        public async Task<List<UsuarioModel>> GetUsuarios()
        {
            var usuarios = (await FindAll(us => (bool)!us.IsDeleted))
                           .Select(us => new UsuarioModel()
                           {
                               Email = us.Email,
                               Id = us.Id,
                               IdRol = us.IdRol,
                               Name = us.Name,
                               NameFoto = us.NameFoto,
                               Phone = us.Phone,
                               UrlFoto = us.UrlFoto

                           }).ToList();

            return usuarios;
        }

        public async override Task Save(Usuario entity)
        {
            await base.Save(entity);
            await base.SaveChanges();
        }


    }
}
