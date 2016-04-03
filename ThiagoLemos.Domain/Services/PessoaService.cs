
using System;
using System.Linq;
using ThiagoLemos.Domain.Entities;
using ThiagoLemos.Domain.Enums;
using ThiagoLemos.Domain.Interfaces.Repositories;
using ThiagoLemos.Domain.Interfaces.Services;

namespace ThiagoLemos.Domain.Services
{
    public class PessoaService: Service<Pessoa>, IPessoaService
    {
        public PessoaService(IPessoaRepository repository )
        {
            this.repo = repository;
        }
        
        public void AdicionarNovaPessoa(Pessoa obj)
        {

            var cpf_repetido = repo.GetAll().Any(x => x.Cpf == obj.Cpf);
            if (cpf_repetido)
            {
                throw new Exception(EnumHelper.Descricao(MensagemErro.CPF_ja_cadastrado));
            }


            this.Adicionar(obj);
        }

        public void AtualizarPessoa(Pessoa pessoa)
        {
            var cnpj_repetido = repo.GetAll().Any(x => x.Cpf == pessoa.Cpf && x.Id != pessoa.Id);
            if (cnpj_repetido)
            {
                throw new Exception(EnumHelper.Descricao(MensagemErro.CPF_ja_cadastrado));
            }

            this.Atualizar(pessoa);
        }

        public void ExcluirPessoa(Pessoa obj)
        {
            if (obj.PossuiColaboradores())
            {
                throw new Exception(EnumHelper.Descricao(MensagemErro.PessoaColaboradoresCadastrados));
            }

            this.Excluir(obj);
        }
    }
}
