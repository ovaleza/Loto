using Loto.Domain.Core;

namespace Loto.Domain.Entities.Lottery
{
    public class Lottery : BaseEntity
    {
        public string Id { get; set; }
        public string? Cia { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Quiniela { get; set; }
        public string? Pale { get; set; }
        public string? Tripleta { get; set; }
        public string? TimeClose { get; set; }
        public string? Priority { get; set; }
        public string? Status { get; set; }
    }
}
