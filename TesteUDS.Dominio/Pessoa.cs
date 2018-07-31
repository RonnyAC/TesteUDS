using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TesteUDS.Dominio {
    public class Pessoa {
        public Guid id { get; set; }

        [DisplayName("Nome: ")]
        [Required(ErrorMessage = "Nome deve ser preenchido")]
        [Remote("NomeUnico", "Pessoa", ErrorMessage = "Este Nome ja esta cadastrado")]
        public String nome { get; set; }

        [DisplayName("Data de nascimento: ")]
        [Required(ErrorMessage = "Data de Nascimento deve ser preenchido")]
        public DateTime dataNascimento { get; set; }

    }
}
