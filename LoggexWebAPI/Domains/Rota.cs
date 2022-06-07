using System;
using System.Collections.Generic;

#nullable disable

namespace LoggexWebAPI.Domains
{
    public partial class Rota
    {
        public int IdRota { get; set; }
        public int? IdSituacao { get; set; }
        public int? IdVeiculo { get; set; }
        public int? IdMotorista { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime? DataPartida { get; set; }
        public DateTime? DataChegada { get; set; }
        public string Carga { get; set; }
        public decimal? PesoBrutoCarga { get; set; }
        public decimal? VolumeCarga { get; set; }
        public string Descricao { get; set; }

        public virtual Motorista IdMotoristaNavigation { get; set; }
        public virtual Situaco IdSituacaoNavigation { get; set; }
        public virtual Veiculo IdVeiculoNavigation { get; set; }
    }
}
