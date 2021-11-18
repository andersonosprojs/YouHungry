using YouHungry.Dominio.Validacao;

namespace YouHungry.Dominio.Entidades
{
    public sealed class Restaurante : BaseEntidade
    {
        public string Cnpj { get; private set; }
        public string Nome { get; private set; }
        public string Especialidade { get; private set; }
        public string Cep { get; private set; }
        public string Endereco { get; private set; }
        public string Cidade { get; private set; }
        public string Senha { get; private set; }

        public Restaurante(string cnpj, string nome, string especialidade, string cep, string endereco, string cidade, string senha) => 
            ValidarDominio(cnpj, nome, especialidade, cep, endereco, cidade, senha);

        public Restaurante(int id, string cnpj, string nome, string especialidade, string cep, string endereco, string cidade, string senha)
        {
            ValidacaoDominioException.When(id < 0, "Valor inválido do Id");

            Id = id;
            ValidarDominio(cnpj, nome, especialidade, cep, endereco, cidade, senha);
        }

        public void Update(string cnpj, string nome, string especialidade, string cep, string endereco, string cidade, string senha)
        {
            ValidarDominio(cnpj, nome, especialidade, cep, endereco, cidade, senha);
        }

        private void ValidarDominio(string cnpj, string nome, string especialidade, string cep, string endereco, string cidade, string senha)
        {
            ValidacaoDominioException.When(string.IsNullOrEmpty(cnpj), "CNPJ inválido! CNPJ é obrigatório");
            ValidacaoDominioException.When(cnpj.Length == 14, "CNPJ inválido! CNPJ deve ter 14 números");

            ValidacaoDominioException.When(string.IsNullOrEmpty(nome), "Nome inválido! Nome é obrigatório.");
            ValidacaoDominioException.When(nome.Length < 3, "Nome inválido! Nome deve ter no mínimo 3 caracteres.");

            ValidacaoDominioException.When(string.IsNullOrEmpty(especialidade), "Especialidade inválida! Especialidade é obrigatória.");

            ValidacaoDominioException.When(string.IsNullOrEmpty(cep), "CEP inválido! CEP é obrigatório.");
            ValidacaoDominioException.When(nome.Length == 8, "CEP inválido! CEP deve ter 8 números.");

            ValidacaoDominioException.When(string.IsNullOrEmpty(endereco), "Endereço inválido! Endereço é obrigatório.");

            ValidacaoDominioException.When(string.IsNullOrEmpty(cidade), "Cidade inválida! Cidade é obrigatória.");

            ValidacaoDominioException.When(string.IsNullOrEmpty(senha), "Senha inválida! Senha é obrigatória.");

            Cnpj = cnpj;
            Nome = nome;
            Especialidade = especialidade;
            Cep = cep;
            Endereco = endereco;
            Cidade = cidade;
            Senha = senha;
        }
    }
}
