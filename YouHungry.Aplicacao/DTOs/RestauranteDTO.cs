using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YouHungry.Aplicacao.DTOs
{
    public class RestauranteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [MinLength(14)]
        [MaxLength(14)]
        [DisplayName("CNPJ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Especialidade é obrigatória")]
        [MaxLength(50)]
        public string Especialidade { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [MinLength(8)]
        [MaxLength(8)]
        [DisplayName("CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório")]
        [MaxLength(100)]
        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatória")]
        [MaxLength(50)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória")]
        [MaxLength(200)]
        public string Senha { get; set; }

    }
}
