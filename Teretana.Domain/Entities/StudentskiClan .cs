using System;
using System.Collections.Generic;
using System.Text;

namespace Teretana.Domain.Entities
{
    public class StudentskiClan : Clan
    {
        public string Fakultet { get; set; } = null!;
        public decimal Popust { get; set; }
    }
}
