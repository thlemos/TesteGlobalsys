using ThiagoLemos.Domain.Entities;
using ThiagoLemos.Domain.Interfaces.Repositories;
using ThiagoLemos.Infra.Contextos;

namespace ThiagoLemos.Infra.Repositories
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(Contexto ctx)
        {
            // TODO: Complete member initialization
            this.db = ctx;
        }
    }
}
