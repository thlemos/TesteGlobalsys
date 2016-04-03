
using System;
using System.Linq;
using ThiagoLemos.Domain.Entities;
using ThiagoLemos.Domain.Enums;
using ThiagoLemos.Domain.Interfaces.Repositories;
using ThiagoLemos.Domain.Interfaces.Services;

namespace ThiagoLemos.Domain.Services
{
    public class EmpresaService: Service<Empresa>, IEmpresaService
    {
        public EmpresaService(IEmpresaRepository repository)
        {
            this.repo = repository;
        }

        public void AdicionarNovaEmpresa(Empresa empresa)
        {
            var cnpj_repetido = repo.GetAll().Any(x => x.Cnpj == empresa.Cnpj);
            if (cnpj_repetido)
            {
                throw new Exception(EnumHelper.Descricao(MensagemErro.CNPJ_ja_cadastrado));
            }

            this.Adicionar(empresa);
        }


        public void AtualizarEmpresa(Empresa empresa)
        {
            var cnpj_repetido = repo.GetAll().Any(x => x.Cnpj == empresa.Cnpj && x.Id != empresa.Id);
            if (cnpj_repetido)
            {
                throw new Exception(EnumHelper.Descricao(MensagemErro.CNPJ_ja_cadastrado));
            }

            this.Atualizar(empresa);
        }


        public void ExcluirEmpresa(Empresa obj)
        {
            
            if (obj.PossuiColaboradores())
            {
                throw new Exception(EnumHelper.Descricao(MensagemErro.EmpresaColaboradoresCadastrados));
            }

            this.Excluir(obj);
        }


    }
}
