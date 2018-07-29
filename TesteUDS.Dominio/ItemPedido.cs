using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteUDS.Dominio {
    public class ItemPedido {
        public Guid id { get; set; }
        public Guid idPedido { get; set; }
        public Produto produto { get; set; }
        public Double quantidade { get; set; }
        public Double precoUnitario { get; set; }
        public Double percentualDesconto { get; set; }
        public Double total { get; set; }
    }
}
