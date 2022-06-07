using System;
using System.Collections.Generic;

#nullable disable

namespace LoggexWebAPI.Domains
{
    public partial class Motorista
    {
        public Motorista()
        {
            Rota = new HashSet<Rota>();
        }

        public int IdMotorista { get; set; }
        public int? IdUsuario { get; set; }
        public string Cnh { get; set; }
        public string NumCelular { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Rota> Rota { get; set; }
    }
}
