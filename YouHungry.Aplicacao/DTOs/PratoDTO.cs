using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YouHungry.Aplicacao.DTOs
{
    public class PratoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Preço é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "O Tempo de Preparo é obrigatório")]
        [MaxLength(50)]
        [DisplayName("Tempo de Preparo")]
        public string TempoPreparo { get; set; }

        [MaxLength(250)]
        [DisplayName("Imagem do Prato")]
        public string Imagem { get; set; }
    }
}
