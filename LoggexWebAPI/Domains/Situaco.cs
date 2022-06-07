using System;
using System.Collections.Generic;

#nullable disable

namespace LoggexWebAPI.Domains
{
    public partial class Situaco
    {
        public Situaco()
        {
            Rota = new HashSet<Rota>();
        }

        public int IdSituacao { get; set; }
        public string TituloSituacao { get; set; }

        public virtual ICollection<Rota> Rota { get; set; }
    }
}
