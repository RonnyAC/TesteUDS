using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteUDS.Dominio {
    public class Pedido {
        public Guid id { get; set; }

        [DisplayName("Nome Cliente")]
        public Pessoa cliente { get; set; }

        [DisplayName("Numero do Pedido")]
        public int numero { get; set; }

        [DisplayName("Data Emissão")]
        public DateTime emissao { get; set; }

        [DisplayName("Total")]
        public Double total { get; set; }


        public List<ItemPedido> item { get; set; }

        public Pedido() {
            id = Guid.Empty;
            emissao = DateTime.Now;
        }


    }
}
