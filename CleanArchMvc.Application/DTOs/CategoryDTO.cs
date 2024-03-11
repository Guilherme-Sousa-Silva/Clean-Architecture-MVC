using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
	public class CategoryDTO
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage ="O nome deve conter no minimo 3 caracteres")]
        public string Name { get; set; }
    }
}
