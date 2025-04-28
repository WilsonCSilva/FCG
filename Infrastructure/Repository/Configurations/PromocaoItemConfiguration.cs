using FCG.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCG.Infrastructure.Repository.Configurations
{
    public class PromocaoItemConfiguration : IEntityTypeConfiguration<PromocaoItem>
    {
        public void Configure(EntityTypeBuilder<PromocaoItem> builder)
        {
            builder.ToTable("PromocaoItem");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnOrder(0).HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.DataCriacao).HasColumnOrder(1).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.GameId).HasColumnOrder(2).HasColumnType("int").IsRequired();
            builder.Property(x => x.PrecoPromocional).HasColumnOrder(3).HasColumnType("decimal(18,2)").IsRequired();
        }
    }
}
