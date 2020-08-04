
using Microsoft.EntityFrameworkCore;
using QuickBuy.Dominio.Entidades;
using QuickBuy.Dominio.ObjetoDeValor;
using QuickBuy.Repositorio.Config;

namespace QuickBuy.Repositorio.Contexto
{
    public class QuickBuyContexto : DbContext
    {
        // o nome "Usuarios" que vai para o banco de dados que vai usar o dbcontext pra criar as tabelas
        // com isso ele vai usar essas propriedades para criar as tabelas na base de dados
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }
        public DbSet<FormaPagamento> FormasPagamentos { get; set; }
        public QuickBuyContexto(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//serve para construir o modelo do contexto(nossa classe)
         //vai criar as classes para o mapeamento no banco referenciando os configurations
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());

            modelBuilder.Entity<FormaPagamento>().HasData(
                new FormaPagamento() {
                    Id = 1,
                    Nome = "Boleto",
                    Descricao = "Forma de pagamento Boleto" },
                new FormaPagamento()
                {
                    Id = 2,
                    Nome = "CartaoCredito",
                    Descricao = "Forma de pagamento Cartao de Crédito"
                },
                new FormaPagamento()
                {
                    Id = 3,
                    Nome = "Deposito",
                    Descricao = "Forma de pagamento Depôsito"
                });


            //referenciamos as configurações no dbcontext para que ele faça as alterações no banco
            base.OnModelCreating(modelBuilder);
        }

    }
}
