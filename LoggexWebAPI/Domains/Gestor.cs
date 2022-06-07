using System;
using System.Collections.Generic;

#nullable disable

namespace LoggexWebAPI.Domains
{
    public partial class Gestor
    {
        public int IdGestor { get; set; }
        public int? IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
