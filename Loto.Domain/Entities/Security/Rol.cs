using System;

namespace Loto.Domain.Entities.Security
{
    public partial class Rol : Core.BaseEntity
    {

        public int Id { get; set; }
        public string? Name { get; set; }

    }
}