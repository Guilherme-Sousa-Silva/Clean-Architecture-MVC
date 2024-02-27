using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Tests.Domain
{
	public class CategoryTests
	{
		[Fact(DisplayName ="Create Category With valid State")]
		public void CrateCategory_WithValidParameters_ResultObjectValidState()
		{
			Action action = () => new Category(1, "Categoria Teste");
			action.Should()
				.NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
		}

		[Fact(DisplayName = "Create Category With Negative Id Value")]
		public void CrateCategory_WithNegativeIdValue_ResultDomainExceptionValidation()
		{
			Action action = () => new Category(-1, "Categoria Teste");
			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
					.WithMessage("Id inválido");
		}

		[Fact(DisplayName = "Create Category With Blanked Name Value")]
		public void CrateCategory_WithBlankedName_ResultDomainExceptionValidation()
		{
			Action action = () => new Category(1, "");
			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
					.WithMessage("Nome inválido. O nome não pode ser nulo!");
		}

		[Fact(DisplayName = "Create Category With Name Shorter Than Three Characteres")]
		public void CrateCategory_WithNameShorterThanThreeCharacteres_ResultDomainExceptionValidation()
		{
			Action action = () => new Category(1, "ab");
			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
					.WithMessage("Nome inválido. O nome deve ter mais que 3 caracteres!");
		}

		[Fact(DisplayName = "Create Category With Null Name")]
		public void CrateCategory_WithNullName_ResultDomainExceptionValidation()
		{
			Action action = () => new Category(1, null);
			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
					.WithMessage("Nome inválido. O nome não pode ser nulo!");
		}
	}
}
