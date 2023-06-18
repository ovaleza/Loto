
namespace Loto.Infrastructure.Models.Usuario
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? IdRol { get; set; }
        public string? UrlFoto { get; set; }
        public string? NameFoto { get; set; }
    }
}
