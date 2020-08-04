using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Repositorio.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {//usamos o haskey para informar a chave primaria no banco
        //o ideal é fazer essa menção aqui, pois se for usar a função do efc(entityframe)
        //ele vai fazer automaticamente, então o exemplo do e-mail
        //vai tentar usar o padrão de caracteres, oque pode atrapalhar quando criar no banco
        //então é melhor dizer como a propriedade usuario deve ser configurado para fazer o mapeamento
            builder.HasKey(u => u.Id);
            //usando o padrão fluent do builder, podemos encadear os metodos que serão usados

            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);

            //a senha fica em hash pq é criptografa e por isso precisa de mmais caracteres
            builder.Property(u => u.Senha).IsRequired().HasMaxLength(400);
            //é obrigatorio no is required // hasmaxlength é o tamanho dele

            builder.Property(u => u.Nome).IsRequired().HasMaxLength(50);
            //quando eu coloca isrequired eu forço o banco a não criar o item vazio
            
            
            builder.Property(u => u.SobreNome).IsRequired().HasMaxLength(50);

            builder.HasMany(u => u.Pedidos)//tem muitos pedidos(hasmany)
                   .WithOne(p => p.Usuario);//terá somente um usuario não pode ter mais que um

        }
    }
}
