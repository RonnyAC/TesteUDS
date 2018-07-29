using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteUDS.Dominio {
    public class Produto {
        public Guid id { get; set; }
        public String codigo { get; set; }
        public String nome { get; set; }
        public Double precoUnitario { get; set; }
    }
}
