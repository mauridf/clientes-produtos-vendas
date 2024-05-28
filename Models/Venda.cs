using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientes_produtos_vendas.Models
{
    public class Venda
    {
        public int VendaID { get; set; }
        public int ClienteID { get; set; }
        public DateTime DataVenda { get; set; }
    }
}
