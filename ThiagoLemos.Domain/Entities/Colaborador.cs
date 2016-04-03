using System;
using ThiagoLemos.Domain.Enums;

namespace ThiagoLemos.Domain.Entities
{
    public class Colaborador
    {
        public Colaborador()
        {
            //para o entity framework
        }

        public Colaborador(int idPessoa, int idEmpresa, string cargo, double salario)
        {
            this.Cargo = cargo;
            this.Salario = salario;
            this.PessoaId = idPessoa;
            this.EmpresaId = idEmpresa;
            Status = Status.Ativo;
        }

        public int Id { get; set; }
        public virtual int EmpresaId { get; set; }

        public virtual int PessoaId { get; set; }

        
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public Status Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataDemissao { get; set; }


        public virtual Pessoa Pessoa { get; set; }
        public virtual Empresa Empresa { get; set; }
        
    }
}
