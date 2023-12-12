using System.Linq;
using CursoEFCore_.Domain;
using CursoEFCore_.ValueObjects;
using Microsoft.EntityFrameworkCore;


namespace CursoEFCore_
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new Data.ApplicationContext();

            //db.Database.Migrate(); //3 forma de Aplicar uma Migração - não Indicada para usar em Produção

            var existe = db.Database.GetPendingMigrations().Any();//validando se existe migração pedente
            if (existe)
            {
                //throw new Exception("Migrations pendentes");
            }

            //InserirDados();
            //InserirDadosEmMassa();
            //ConsultandoDados();
            //CadastrarPedido();
            //ConsultarPedidoCarregamentoAdiantado(); 
            //AtualizarDados();
        }

        private static void RemoverRegistro()
        {
            using var db = new Data.ApplicationContext();

            //var cliente = db.Clientes.Find(2);
            var cliente = new Cliente { Id = 3 };
            //db.Clientes.Remove(cliente);
            //db.Remove(cliente);
            db.Entry(cliente).State = EntityState.Deleted;

            db.SaveChanges();
        }

        private static void AtualizarDados()
        {
            using var db = new Data.ApplicationContext();
            //var cliente = db.Clientes.Find(1);
            //cliente.Nome = "Nome Novo"

            var cliente = new Cliente
            {
                Id = 1
            };

            var clienteDesconectado = new
            {
                Nome = "Cliente Desconectado Passo 3",
                Telefone = "7966669999"
            };

            db.Attach(cliente);
            db.Entry(cliente).CurrentValues.SetValues(clienteDesconectado);

            //db.Clientes.Update(cliente);//sem esse método atualiza so os campos modificados
            db.SaveChanges();
        }

        private static void ConsultarPedidoCarregamentoAdiantado() {
            using var db = new Data.ApplicationContext();
            var pedidos = db
                .Pedidos
                .Include(p => p.Itens)
                    .ThenInclude(p => p.Produto)
                .ToList();

            Console.WriteLine(pedidos.Count);
        }

        private static void CadastrarPedido()
        {
            using var db = new Data.ApplicationContext();

            var cliente = db.Clientes.FirstOrDefault();//consulta
            var produto = db.Produtos.FirstOrDefault();

  

            var pedido = new Pedido
            {
                ClientId = cliente.Id,
                IniciadoEm = DateTime.Now,
                FinalizadoEm = DateTime.Now,
                Observacao = "Pedido Teste",
                Status = StatusPedido.Analise,
                TipoFrete = TipoFrete.SemFrete,
                Itens = new List<PedidoItem>
                 {
                     new PedidoItem
                     {
                         ProdutoId = produto.Id,
                         Desconto = 0,
                         Qtd = 1,
                         Valor = 10,
                     }
                 }
            };

            db.Pedidos.Add(pedido);

            db.SaveChanges();
        }


        private static void ConsultandoDados() 
        {
            using var db = new Data.ApplicationContext();
            //var consultaPorSintaxe = (from c in db.Clientes where c.Id > 0 select c).ToList();
            var consultaPorMetodo = db.Clientes.Where(p=>p.Id>0).OrderBy(p=>p.Id).ToList(); //db.Clientes.AsNoTracking().Where(p=>p.Id>0).ToList(); - informar para o EF p não encontrar os obj em memória, mas sim diretamente na base de dados
            foreach (var cliente in consultaPorMetodo)
            {
                Console.WriteLine($"Consultando Cliente: {cliente.Id}");
                //db.Clientes.Find(cliente.Id);
                db.Clientes.FirstOrDefault(p=>p.Id==cliente.Id);
            }
        }

        private static void InserirDadosEmMassa()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234567891231",
                Valor = 10,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };
            var cliente = new Cliente
            {
                Nome = "Rafael Almeida",
                CEP = "99999999",
                Cidade = "Itabaina",
                Estado = "SE",
                Telefone = "99000001111"
            };

            var listaClientes = new[]
            {
                new Cliente
                {
                    Nome = "Rafael Almeida",
                    CEP = "99999999",
                    Cidade = "Itabaina",
                    Estado = "SE",
                    Telefone =  "99000001111"
                },
                new Cliente
                {
                    Nome = "Rafael Almeida",
                    CEP = "99999999",
                    Cidade = "Itabaina",
                    Estado = "SE",
                    Telefone =  "99000001111"
                }
            };

            using var db = new Data.ApplicationContext();
            //db.AddRange(produto, cliente);

            db.Set<Cliente>().AddRange(listaClientes);
            //db.Clientes.AddRange(listaClientes);

            var registros = db.SaveChanges();
            Console.WriteLine($"Total Registros(s): {registros}");
        }


        private static void InserirDados()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234567891231",
                Valor = 10,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };
            using var db = new Data.ApplicationContext();//instancia do COntexto
            //1 opção
            //db.Produtos.Add(produto);Ataves da propriedade criada na Application Context
            //2
            //db.Set<Produto>().Add(produto);Metodo Genérico
            //3
            //db.Entry(produto).State = EntityState.Added;Forçando rastreamento de determinada entidade;
            db.Add(produto);//A partir da instancia do db

            var registros = db.SaveChanges();
            Console.WriteLine($"Total Registros(s): {registros}");
        }

    }
}