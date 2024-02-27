using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Tests.Domain
{
	public class ProductTests
	{
		[Fact(DisplayName ="Create product with valid parameters")]
		public void CreateProduct_WithValidParamteres_ResultValidObjectState()
		{
			Action action = () => new Product(1, "produto", "descrição", 10, 2, "imagem");
			action.Should()
				.NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
		}

		[Fact(DisplayName = "Create product with negative Id ")]
		public void CreateProduct_WithNegativeId_ResultDomainExceptionValidation()
		{
			Action action = () => new Product(-1, "produto", "descrição", 10, 2, "imagem");
			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
		}

		[Fact(DisplayName = "Create product With Blanked Name Value")]
		public void CrateProduct_WithBlankedName_ResultDomainExceptionValidation()
		{
			Action action = () => new Product(1, "", "descrição", 10, 2, "imagem");
			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
					.WithMessage("Produto inválido. O nome do produto não pode ser nulo!");
		}

		[Fact(DisplayName = "Create product With Name Shorter Than Three Characteres")]
		public void CrateProduct_WithNameShorterThanThreeCharacteres_ResultDomainExceptionValidation()
		{
			Action action = () => new Product(1, "ab", "descrição", 10, 2, "imagem");
			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
					.WithMessage("Produto inválido. O nome do produto deve ter mais que 3 caracteres!");
		}

		[Fact(DisplayName = "Create product With Blanked description Value")]
		public void CrateProduct_WithBlankedDescription_ResultDomainExceptionValidation()
		{
			Action action = () => new Product(1, "produto", "", 10, 2, "imagem");
			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
					.WithMessage("Produto inválido. A Descrição do produto não pode ser nula!");
		}

		[Fact(DisplayName = "Create product With invalid price Value")]
		public void CrateProduct_WithInvalidPriceValue_ResultDomainExceptionValidation()
		{
			Action action = () => new Product(1, "produto", "descrição", -10, 2, "imagem");
			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
					.WithMessage("Produto inválido. O preço do produto deve ser maior que zero!");
		}

		[Fact(DisplayName = "Create product With invalid stock Value")]
		public void CrateProduct_WithInvalidStockValue_ResultDomainExceptionValidation()
		{
			Action action = () => new Product(1, "produto", "descrição", 10, -1, "imagem");
			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
					.WithMessage("Produto inválido. O estoque do produto não pode ser negativo!");
		}

		[Fact(DisplayName = "Create product With imagem longer than 250 characteres")]
		public void CrateProduct_WithLongImage_ResultDomainExceptionValidation()
		{
			Action action = () => new Product(1, "produto", "descrição", 10, 1, "imagemaasdaidjaijsdoaisjdsoaijdoaijdaoijdaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaiodjaoidjsaimagemaasdaidjaijsdoaisjdsoaijdoaijdaoijdaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaiodjaoidjsaimagemaasdaidjaijsdoaisjdsoaijdoaijdaoijdaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaoidjaiodjaoidjsa");
			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
					.WithMessage("Produto inválido. A imagem do produto não pode ter mais que 250 caracteres!");
		}

		[Fact(DisplayName = "Create product With null image Value")]
		public void CrateProduct_WithNullImageValue_ResultDomainExceptionValidation()
		{
			Action action = () => new Product(1, "produto", "descrição", 10, 1, null);
			action.Should()
				.NotThrow<NullReferenceException>();
		}

	}
}
