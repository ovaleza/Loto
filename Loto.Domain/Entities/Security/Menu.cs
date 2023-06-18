namespace Loto.Domain.Entities.Security
{
    public partial class Menu : Core.BaseEntity
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? IdMenuFather { get; set; }
        public string? Icon { get; set; }
        public string? Controller { get; set; }
        public string? ActionPage { get; set; }


    }
}