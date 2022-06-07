using System;
using System.Collections.Generic;

#nullable disable

namespace LoggexWebAPI.Domains
{
    public partial class Peca
    {
        public Peca()
        {
            LogAlteracaos = new HashSet<LogAlteracao>();
        }

        public int IdPeca { get; set; }
        public int? IdTipoPeca { get; set; }
        public int? IdVeiculo { get; set; }
        public bool EstadoPeca { get; set; }
        public string ImgPeca { get; set; }
        public string ImgPecaC { get; set; }
        public decimal? Semelhanca { get; set; }

        public virtual TiposPeca IdTipoPecaNavigation { get; set; }
        public virtual Veiculo IdVeiculoNavigation { get; set; }
        public virtual ICollection<LogAlteracao> LogAlteracaos { get; set; }
    }
}
