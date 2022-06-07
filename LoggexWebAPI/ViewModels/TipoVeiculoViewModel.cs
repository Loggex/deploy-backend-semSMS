using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.ViewModels
{
    public class TipoVeiculoViewModel
    {
        public int IdTipoVeiculo { get; set; }
        public string TipoCarreta { get; set; }
        public string TipoVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public string TipoCarroceria { get; set; }
        public List<string> Pecas { get; set; }
    }
}
