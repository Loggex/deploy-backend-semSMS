using System;
using System.Collections.Generic;

#nullable disable

namespace LoggexWebAPI.Domains
{
    public partial class TiposPeca
    {
        public TiposPeca()
        {
            Pecas = new HashSet<Peca>();
        }

        public int IdTipoPeca { get; set; }
        public int? IdTipoVeiculo { get; set; }
        public string NomePeça { get; set; }

        public virtual TiposVeiculo IdTipoVeiculoNavigation { get; set; }
        public virtual ICollection<Peca> Pecas { get; set; }
    }
}
