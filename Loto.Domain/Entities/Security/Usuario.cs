namespace Loto.Domain.Entities.Security
{
    public partial class Usuario : Core.BaseEntity
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? IdRol { get; set; }
        public string? UrlFoto { get; set; }
        public string? NameFoto { get; set; }
        public string? Password { get; set; }


    }
}