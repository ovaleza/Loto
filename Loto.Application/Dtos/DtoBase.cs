using System;
using System.Collections.Generic;
using System.Text;

namespace Loto.Application.Dtos
{
    public class DtoBase
    {
        public int Id { get; set; }
        public int? IdUser { get; set; }
        public DateTime? Date { get; set; }
    }
}
