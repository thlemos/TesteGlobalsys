using ThiagoLemos.Domain.Entities;
using ThiagoLemos.Domain.Interfaces.Repositories;
using ThiagoLemos.Infra.Contextos;

namespace ThiagoLemos.Infra
{
    public class ColaboradorRepository : Repository<Colaborador>, IColaboradorRepository
    {

        public ColaboradorRepository(Contexto ctx)
        {
            // TODO: Complete member initialization
            this.db = ctx;
        }
    }
}
