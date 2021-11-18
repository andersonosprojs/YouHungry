using System.Collections.Generic;
using YouHungry.Dominio.Validacao;

namespace YouHungry.Dominio.Entidades
{
    public sealed class Acompanhamento : BaseEntidade
    {
        public string Nome { get; private set; }

        public Acompanhamento(string nome) => 
            ValidarDominio(nome);

        public Acompanhamento(int id, string nome)
        {
            ValidacaoDominioException.When(id < 0, "Valor inválido do Id");

            Id = id;
            ValidarDominio(nome);
        }

        public void Update(string nome) => ValidarDominio(nome);

        private void ValidarDominio(string nome)
        {
            ValidacaoDominioException.When(string.IsNullOrEmpty(nome), "Nome inválido! Nome é obrigatório.");
            ValidacaoDominioException.When(nome.Length < 3, "Nome inválido! Nome deve ter no mínimo 3 caracteres.");

            Nome = nome;
        }

        public ICollection<Prato> Pratos { get; set; }
    }
}
