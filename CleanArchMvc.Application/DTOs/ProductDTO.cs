using CleanArchMvc.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
	public class ProductDTO
	{
		public int Id {  get; set; }

		[Required(ErrorMessage = "O nome é obrigatório!")]
		[MinLength(3)]
		public string Name { get; set; }

		[Required(ErrorMessage = "A descrição é obrigatória!")]
		[MinLength(5)]
		public string Description { get; set; }

		[Required(ErrorMessage = "O preço é obrigatório!")]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "O estoque é obrigatório!")]
		[Range(1, 999, ErrorMessage ="O estoque é obrigatório!")]
		public int Stock { get; set; }
		public string? Image { get; set; }

		[Required(ErrorMessage = "A categoria é obrigatória!")]
		public int CategoryId { get; set; }
		public Category? Category { get; private set; }
	}
}
