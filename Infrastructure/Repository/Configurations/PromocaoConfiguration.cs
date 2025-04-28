using FCG.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCG.Infrastructure.Repository.Configurations
{
    public class PromocaoConfiguration : IEntityTypeConfiguration<Promocao>
    {
        public void Configure(EntityTypeBuilder<Promocao> builder)
        {
            builder.ToTable("Promocao");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnOrder(0).HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.DataCriacao).HasColumnOrder(1).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataInicioPromocao) .HasColumnOrder(2).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataFimPromocao).HasColumnOrder(3).HasColumnType("datetime").IsRequired();

            builder.HasMany(x => x.Itens)
                .WithOne(y => y.Promocao);
        }
    }
}
