using System;
using System.Collections.Generic;

#nullable disable

namespace LoggexWebAPI.Domains
{
    public partial class TiposVeiculo
    {
        public TiposVeiculo()
        {
            TiposPecas = new HashSet<TiposPeca>();
            Veiculos = new HashSet<Veiculo>();
        }

        public int IdTipoVeiculo { get; set; }
        public string TipoCarreta { get; set; }
        public string TipoVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public string TipoCarroceria { get; set; }

        public virtual ICollection<TiposPeca> TiposPecas { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}
