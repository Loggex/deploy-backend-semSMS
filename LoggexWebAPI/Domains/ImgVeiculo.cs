using System;
using System.Collections.Generic;

#nullable disable

namespace LoggexWebAPI.Domains
{
    public partial class ImgVeiculo
    {
        public int IdImagem { get; set; }
        public int? IdVeiculo { get; set; }
        public string EnderecoImagem { get; set; }

        public virtual Veiculo IdVeiculoNavigation { get; set; }
    }
}
