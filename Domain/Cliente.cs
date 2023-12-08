using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CursoEFCore_.Domain
{
    //[Table("Clientes")]//vai ser o nome da Tabela //Ex DataAnnotations
    internal class Cliente
    {
       // [Key]
        public int Id { get; set; }
       // [Required]
        public string Nome { get; set; }
        //[Column("Phone")]//vai ser o nome da coluna
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
    }
}
