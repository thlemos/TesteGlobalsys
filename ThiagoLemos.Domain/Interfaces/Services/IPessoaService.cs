using System.Security.Cryptography.X509Certificates;
using ThiagoLemos.Domain.Entities;

namespace ThiagoLemos.Domain.Interfaces.Services
{
    public interface IPessoaService : IService<Pessoa>
    {
        void AdicionarNovaPessoa(Pessoa obj);

        void ExcluirPessoa(Pessoa obj);

        void AtualizarPessoa(Pessoa pessoa);
    }
}