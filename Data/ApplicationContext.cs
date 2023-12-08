using Microsoft.EntityFrameworkCore;
using CursoEFCore_.Domain;
using CursoEFCore_.Data.Configurations;

//Responsável por estabelcer uma sessão entre a aplicação e o banco de dados - Fazer mapeamento do BD  
namespace CursoEFCore_.Data
{
    internal class ApplicationContext : DbContext
    {
        //Duas formas de informar o Modelo de dados para EF core
        //1
        //public DbSet<Pedido> Pedidos { get; set; }//"Automaticamente" Criaria 4 tabelas, foi oq o homem disse

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//Configurar a string de conexão
        {
            optionsBuilder.UseSqlServer("Data source=(lcoaldb)\\mssqllocaldb;Initial Catalog=CursoEFCore;Integrated Security=true");
        }

        //2
        protected override void OnModelCreating(ModelBuilder modelBuilder)//Configurar a string de conexão  //Mapeamento utilizando Fluent API - Forma mais rica de Mapeamento
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);//Procure todas as classes concretas que estão implementando o IEntityTypeConfiguration nesse Assembly 
        }
    }
}
