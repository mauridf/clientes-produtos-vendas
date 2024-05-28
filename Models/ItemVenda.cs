using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientes_produtos_vendas.Models
{
    public class ItemVenda
    {
        public int ItemVendaID { get; set; }
        public int VendaID { get; set; }
        public int ProdutoID { get; set; }
        public int Quantidade { get; set; }
    }
}
