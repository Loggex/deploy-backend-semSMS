using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.ViewModels
{
    public class CredMotoristaViewModel
    {
        [Required(ErrorMessage = "informe o telefone do usuário!")]
        public string Telefone { get; set; }
    }
}
