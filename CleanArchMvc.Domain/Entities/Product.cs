using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
	public sealed class Product : EntityBase
	{
		public Product(string name, string description, decimal price, int stock, string image)
		{
			Validate(name, description, price, stock, image);
		}

		public Product(int id, string name, string description, decimal price, int stock, string image)
		{
			DomainExceptionValidation.When(id < 0, "Id inválido");
			Id = id;
			Validate(name, description, price, stock, image);
		}

		public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string? Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public void Validate(string name, string description, decimal price, int stock, string image)
        {
			DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Produto inválido. O nome do produto não pode ser nulo!");
			DomainExceptionValidation.When(name.Length < 3, "Produto inválido. O nome do produto deve ter mais que 3 caracteres!");
			DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Produto inválido. A Descrição do produto não pode ser nula!");
			DomainExceptionValidation.When(price <= 0, "Produto inválido. O preço do produto deve ser maior que zero!");
			DomainExceptionValidation.When(stock < 0, "Produto inválido. O estoque do produto não pode ser negativo!");
			DomainExceptionValidation.When(image?.Length > 250, "Produto inválido. A imagem do produto não pode ter mais que 250 caracteres!");

			Name = name;
			Description = description;
			Price = price;
			Stock = stock;
			Image = image;
		}

		public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
		{
			Validate(name, description, price, stock, image);
			CategoryId = categoryId;
		}
    }
}
