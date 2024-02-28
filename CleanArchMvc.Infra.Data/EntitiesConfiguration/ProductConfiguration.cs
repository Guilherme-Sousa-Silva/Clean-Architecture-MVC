using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			// chave primária
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.IsRequired()
				.HasColumnType("VARCHAR")
				.HasMaxLength(60);

			builder.Property(x => x.Description)
				.IsRequired()
				.HasColumnType("VARCHAR")
				.HasMaxLength(150);

			builder.Property(x => x.Price)
				.IsRequired()
				.HasPrecision(10, 2);

			builder.Property(x => x.Image)
				.HasDefaultValue(null)
				.HasMaxLength(250);

			// mapeamento um para muitos
			builder.HasOne(x => x.Category)
				.WithMany(x => x.Products)
				.HasForeignKey(x => x.CategoryId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
