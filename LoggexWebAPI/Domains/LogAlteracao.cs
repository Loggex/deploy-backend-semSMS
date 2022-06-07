using System;
using System.Collections.Generic;

#nullable disable

namespace LoggexWebAPI.Domains
{
    public partial class LogAlteracao
    {
        public int IdLog { get; set; }
        public int? IdPeca { get; set; }
        public bool EstadoAlteracao { get; set; }
        public DateTime DataAlteracao { get; set; }

        public virtual Peca IdPecaNavigation { get; set; }
    }
}
