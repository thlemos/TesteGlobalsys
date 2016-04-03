
using System;
using System.Linq;
using ThiagoLemos.Domain.Entities;
using ThiagoLemos.Domain.Enums;
using ThiagoLemos.Domain.Interfaces.Repositories;
using ThiagoLemos.Domain.Interfaces.Services;

namespace ThiagoLemos.Domain.Services
{
    public class ColaboradorService: Service<Colaborador>, IColaboradorService
    {
        public ColaboradorService(IColaboradorRepository repository)
        {
            this.repo = repository;
        }

        public void AdicionarNovoColaborador(Colaborador colaborador)
        {
            var verifica = repo.GetAll().Any(x => x.EmpresaId == colaborador.EmpresaId && x.PessoaId == colaborador.PessoaId);
            if (verifica)
            {
                throw new Exception(EnumHelper.Descricao(MensagemErro.Pessoa_ja_colaborador_Empresa));
            }


            repo.Add(colaborador);
            repo.Save();
        }



        public void AtualizarColaborador(Colaborador colaborador)
        {
            var verifica = repo.GetAll().Any(x => x.EmpresaId == colaborador.EmpresaId && x.PessoaId == colaborador.PessoaId && x.Id != colaborador.Id);
            if (verifica)
            {
                throw new Exception(EnumHelper.Descricao(MensagemErro.Pessoa_ja_colaborador_Empresa));
            }
            repo.Update(colaborador);
            repo.Save();
            
        }

        public void ExcluirColaborador(Colaborador colaborador)
        {
            repo.Delete(colaborador);
            repo.Save();
        }

        public void Demitir(Colaborador colaborador)
        {
            colaborador.Status = Status.Inativo;
            colaborador.DataDemissao = DateTime.Now;
            repo.Update(colaborador);
            repo.Save();
        }
    }
}
