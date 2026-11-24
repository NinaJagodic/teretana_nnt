using System;
using System.Collections.Generic;
using System.Text;

namespace Teretana.Domain.Entities
{
    public class Trening
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = null!;
        public string Trener { get; set; } = null!;
        public int Kapacitet { get; set; }
        public DateTime TerminPocetka { get; set; }
        public ICollection<PrijavaNaTrening> Prijave { get; set; } = new List<PrijavaNaTrening>();
    }
}
