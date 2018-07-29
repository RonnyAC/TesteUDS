using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteUDS.Dominio {
    public class Pedido {
        public Guid id { get; set; }
        public Pessoa cliente { get; set; }
        public int numero { get; set; }
        public DateTime emissao { get; set; }
        public Double total { get; set; }
        public List<ItemPedido> item { get; set; }
    }
}
