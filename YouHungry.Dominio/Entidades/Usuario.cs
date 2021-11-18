using YouHungry.Dominio.Validacao;

namespace YouHungry.Dominio.Entidades
{
    public sealed class Usuario : BaseEntidade
    {
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public string Cep { get; private set; }
        public string Endereco { get; private set; }
        public string Cidade { get; private set; }
        public string Senha { get; private set; }

        public Usuario(string email, string nome, string cep, string endereco, string cidade, string senha) => 
            ValidarDominio(email, nome, cep, endereco, cidade, senha);

        public Usuario(int id, string email, string nome, string cep, string endereco, string cidade, string senha)
        {
            ValidacaoDominioException.When(id < 0, "Valor inválido do Id");

            Id = id;
            ValidarDominio(email, nome, cep, endereco, cidade, senha);
        }

        public void Update(string email, string nome, string cep, string endereco, string cidade, string senha)
        {
            ValidarDominio(email, nome, cep, endereco, cidade, senha);
        }

        private void ValidarDominio(string email, string nome, string cep, string endereco, string cidade, string senha)
        {
            ValidacaoDominioException.When(string.IsNullOrEmpty(email), "E-mail inválido! E-mail é obrigatório");

            ValidacaoDominioException.When(string.IsNullOrEmpty(nome), "Nome inválido! Nome é obrigatório.");
            ValidacaoDominioException.When(nome.Length < 3, "Nome inválido! Nome deve ter no mínimo 3 caracteres.");

            ValidacaoDominioException.When(string.IsNullOrEmpty(cep), "CEP inválido! CEP é obrigatório.");
            ValidacaoDominioException.When(nome.Length == 8, "CEP inválido! CEP deve ter 8 números.");

            ValidacaoDominioException.When(string.IsNullOrEmpty(endereco), "Endereço inválido! Endereço é obrigatório.");

            ValidacaoDominioException.When(string.IsNullOrEmpty(cidade), "Cidade inválida! Cidade é obrigatória.");

            ValidacaoDominioException.When(string.IsNullOrEmpty(senha), "Senha inválida! Senha é obrigatória.");

            Email = email;
            Nome = nome;
            Cep = cep;
            Endereco = endereco;
            Cidade = cidade;
            Senha = senha;
        }
    }
}
