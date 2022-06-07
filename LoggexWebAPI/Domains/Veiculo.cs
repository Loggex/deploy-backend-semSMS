using System;
using System.Collections.Generic;

#nullable disable

namespace LoggexWebAPI.Domains
{
    public partial class Veiculo
    {
        public Veiculo()
        {
            ImgVeiculos = new HashSet<ImgVeiculo>();
            Pecas = new HashSet<Peca>();
            Rota = new HashSet<Rota>();
        }

        public int IdVeiculo { get; set; }
        public int IdTipoVeiculo { get; set; }
        public string Placa { get; set; }
        public int? AnoFabricacao { get; set; }
        public bool? Seguro { get; set; }
        public string Cor { get; set; }
        public string Chassi { get; set; }
        public bool EstadoVeiculo { get; set; }
        public decimal? Quilometragem { get; set; }
        public string Descricao { get; set; }

        public virtual TiposVeiculo IdTipoVeiculoNavigation { get; set; }
        public virtual ICollection<ImgVeiculo> ImgVeiculos { get; set; }
        public virtual ICollection<Peca> Pecas { get; set; }
        public virtual ICollection<Rota> Rota { get; set; }
    }
}
