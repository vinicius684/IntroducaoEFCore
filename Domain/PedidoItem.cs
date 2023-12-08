using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoEFCore_.Domain
{
    internal class PedidoItem
    {
        public int Id { get; set; }
        public int PedidoId { get; set;}
        public Pedido Pedido { get; set;}//????????
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }//quando carregar o Pedido item, vai saber o detalhe do produto
        public int Qtd { get; set; }
        public double Valor { get; set; }//não aceitou double na hora da migration - do custo estava com decimal 
        public double Desconto { get; set; }//não aceitou double na hora da migration - do custo estava com decimal 
    }
}
