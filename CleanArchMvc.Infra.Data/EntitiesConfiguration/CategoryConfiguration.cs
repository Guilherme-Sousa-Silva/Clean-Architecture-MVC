using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			// chave primária
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.IsRequired()
				.HasColumnType("VARCHAR")
				.HasMaxLength(60);

			// propriedade para popular as tabelas na hora de rodar as migrations
			builder.HasData(
				new Category(1, "Material escolar"),
				new Category(2, "Eletrônicos"),
				new Category(3, "Acessórios")
				);
		}
	}
}
