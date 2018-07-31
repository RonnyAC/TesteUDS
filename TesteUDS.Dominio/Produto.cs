using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TesteUDS.Dominio {
    public class Produto {
        public Guid id { get; set; }

        [DisplayName("Código: ")]
        [Required(ErrorMessage = "Codigo deve ser preenchido")]
        [Remote("CodigoUnico", "Produto", ErrorMessage ="Este Codigo ja esta cadastrado")]
        public String codigo { get; set; }

        [DisplayName("Nome: ")]
        [Required(ErrorMessage = "Nome deve ser preenchido")]
        [Remote("NomeUnico", "Produto", ErrorMessage = "Este Nome ja esta cadastrado")]
        public String nome { get; set; }

        [DisplayName("Preço Unitário: ")]
        [Required(ErrorMessage = "Preço Unitario deve ser preenchido")]
        [Range(0.0, Double.MaxValue, ErrorMessage ="Valor deve ser Maior que zero" )]
        public Double precoUnitario { get; set; }
    }
}
