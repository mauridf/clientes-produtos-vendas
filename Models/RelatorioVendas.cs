using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientes_produtos_vendas.Models
{
    public class RelatorioVenda
    {
        public int VendaId { get; set; }
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataVenda { get; set; }
    }
}
