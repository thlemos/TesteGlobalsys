using ThiagoLemos.Domain.Entities;

namespace ThiagoLemos.Domain.Interfaces.Services
{
    public interface IEmpresaService : IService<Empresa>
    {

        void AdicionarNovaEmpresa(Empresa empresa);

        void ExcluirEmpresa(Empresa obj);

        void AtualizarEmpresa(Empresa empresa);
    }
}