using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
	public class CategoryDTO
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
