using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
	public sealed class Category : EntityBase
	{
		public Category(string name)
		{
			Validate(name);
		}

		public Category(int id, string name)
		{
			DomainExceptionValidation.When(id < 0, "Id inválido");
			Id = id;
			Validate(name);
		}

        public string Name { get; private set; }
        public IList<Product> Products { get; set; }

		public void Validate(string name) 
		{
			DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido. O nome não pode ser nulo!");
			DomainExceptionValidation.When(name.Length < 3, "Nome inválido. O nome deve ter mais que 3 caracteres!");
			Name = name;
        }

		public void Update(string name)
		{
			Validate(name);
		}
    }
}
