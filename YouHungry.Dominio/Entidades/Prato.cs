using YouHungry.Dominio.Validacao;

namespace YouHungry.Dominio.Entidades
{
    public sealed class Prato : BaseEntidade
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double Preco { get; private set; }
        public string TempoPreparo { get; private set; }
        public string Imagem { get; private set; }

        public Prato(string nome, string descricao, double preco, string tempoPreparo, string imagem) =>
            ValidarDominio(nome, descricao, preco, tempoPreparo, imagem);

        public Prato(int id, string nome, string descricao, double preco, string tempoPreparo, string imagem)
        {
            ValidacaoDominioException.When(id < 0, "Valor inválido do Id");

            Id = id;
            ValidarDominio(nome, descricao, preco, tempoPreparo, imagem);
        }

        public void Update(string nome, string descricao, double preco, string tempoPreparo, string imagem, long restauranteId/*, long acompanhamentoId*/)
        {
            ValidarDominio(nome, descricao, preco, tempoPreparo, imagem);

            RestauranteId = restauranteId;
            //AcompanhamentoId = acompanhamentoId;
        }

        private void ValidarDominio(string nome, string descricao, double preco, string tempoPreparo, string imagem)
        {
            ValidacaoDominioException.When(string.IsNullOrEmpty(nome), "Nome inválido! Nome é obrigatório.");
            ValidacaoDominioException.When(nome.Length < 3, "Nome inválido! Nome deve ter no mínimo 3 caracteres.");

            ValidacaoDominioException.When(string.IsNullOrEmpty(descricao), "Descrição inválido! Descrição é obrigatório.");
            ValidacaoDominioException.When(descricao.Length < 3, "Descrição inválido! Descrição deve ter no mínimo 3 caracteres.");

            ValidacaoDominioException.When(preco < 0, "Valor inválido para preço.");

            ValidacaoDominioException.When(string.IsNullOrEmpty(tempoPreparo), "Tempo de Preparo inválido! Tempo de Preparo é obrigatório.");

            ValidacaoDominioException.When(imagem?.Length > 250, "Tamanho da imagem inválida! O Tamanho da imagem deve ter no máximo 250 caracteres.");

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            TempoPreparo = tempoPreparo;
            Imagem = imagem;
        }

        public long RestauranteId { get; set; }
        public Restaurante restaurante { get; set; }

        //public long AcompanhamentoId { get; set; }
        //public Acompanhamento acompanhamento { get; set; }
    }
}
