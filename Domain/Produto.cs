using CursoEFCore_.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoEFCore_.Domain
{
    internal class Produto
    {
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Descricao { get; set;}
        public double Valor { get; set;} //não aceitou decimal na hora da migration - do curso estava com decimal 
        public TipoProduto TipoProduto { get; set; }
        public bool Ativo { get; set; }
    }
}
