

using System;

namespace Loto.Domain.Entities.Configuration
{
    public partial class Numeration
    {
        public int Id { get; set; }
        public int? LastNumber { get; set; }
        public int? Digits { get; set; }
        public string? Gestion { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}