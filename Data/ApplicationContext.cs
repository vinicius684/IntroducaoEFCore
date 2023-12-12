using Microsoft.EntityFrameworkCore;
using CursoEFCore_.Domain;
using CursoEFCore_.Data.Configurations;
using Microsoft.Extensions.Logging;

//Responsável por estabelcer uma sessão entre a aplicação e o banco de dados - Fazer mapeamento do BD  
namespace CursoEFCore_.Data
{
    internal class ApplicationContext : DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole()); //informar o EF core, qual o log ele vai utilizar pra escrever as instruções no Console
        
        //Duas formas de informar o Modelo de dados para EF core
        //1
        public DbSet<Pedido> Pedidos { get; set; }//"Automaticamente" Criaria 4 tabelas, foi oq o homem disse
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//Configurar a string de conexão
        {
            optionsBuilder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging()
                .UseSqlServer("Data source=(localdb)\\mssqllocaldb;Initial Catalog=CursoEFCore;Integrated Security=true", p=>p.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null).MigrationsHistoryTable("curso_ef_core"));//Segundo argumento: resiliencia de conexão(vai tentar acessar o BD mais de uma vez)
        }

        //2
        protected override void OnModelCreating(ModelBuilder modelBuilder)//Configurar a string de conexão  //Mapeamento utilizando Fluent API - Forma mais rica de Mapeamento
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);//Procure todas as classes concretas que estão implementando o IEntityTypeConfiguration nesse Assembly 
            MapearPropriedadesEsquecidas(modelBuilder);
        }

        private void MapearPropriedadesEsquecidas(ModelBuilder modelBuilder) //Bonus 
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));

                foreach (var property in properties)
                {
                    if (string.IsNullOrEmpty(property.GetColumnType())
                        && !property.GetMaxLength().HasValue)
                    {
                        //property.SetMaxLength(100);
                        property.SetColumnType("VARCHAR(100)");
                    }
                }
            }
        }
    }
}
