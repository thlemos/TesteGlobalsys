
using ThiagoLemos.Domain;
using ThiagoLemos.Domain.Entities;
using ThiagoLemos.Domain.Interfaces.Repositories;
using ThiagoLemos.Infra.Contextos;

namespace ThiagoLemos.Infra
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(Contexto ctx)
        {
            // TODO: Complete member initialization
            this.db = ctx;
        }
    }
}
