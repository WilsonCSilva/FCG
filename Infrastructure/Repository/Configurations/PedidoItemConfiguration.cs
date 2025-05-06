using FCG.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCG.Infrastructure.Repository.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItem");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnOrder(0).HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.DataCriacao).HasColumnOrder(1).HasColumnType("date").IsRequired();
            builder.Property(x => x.GameId).HasColumnOrder(2).HasColumnType("int").IsRequired();
            builder.Property(x => x.PedidoId).HasColumnOrder(3).HasColumnType("int").IsRequired();
            builder.Property(x => x.QuantidadePedido).HasColumnOrder(4).HasColumnType("int").IsRequired();
        }
    }
}
