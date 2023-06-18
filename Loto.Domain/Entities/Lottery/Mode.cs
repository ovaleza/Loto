using Loto.Domain.Core;

namespace Loto.Domain.Entities.Lottery
{
    public class Mode  : BaseEntity
    {
        public string Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
    }
}
