using ThiagoLemos.Domain.Entities;

namespace ThiagoLemos.Domain.Interfaces.Services
{
    public interface IColaboradorService : IService<Colaborador>
    {

        void AdicionarNovoColaborador(Colaborador colaborador);



        void AtualizarColaborador(Colaborador colaborador);

        void ExcluirColaborador(Colaborador colaborador);

        void Demitir(Colaborador colaborador);
    }
}