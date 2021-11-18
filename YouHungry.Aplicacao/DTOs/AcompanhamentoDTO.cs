using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YouHungry.Aplicacao.DTOs
{
    public class AcompanhamentoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }
    }
}
