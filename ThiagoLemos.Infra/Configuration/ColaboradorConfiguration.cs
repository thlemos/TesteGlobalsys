using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using ThiagoLemos.Domain.Entities;

namespace ThiagoLemos.Infra.Configuration
{
    public class ColaboradorConfiguration : EntityTypeConfiguration<Colaborador>
    {
        public ColaboradorConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Cargo)
                .IsRequired();

            Property(x => x.Salario)
                .IsRequired();

            Property(x => x.Status)
                .IsRequired();

            Property(x => x.DataCadastro )
                .IsRequired();

            Property(x => x.DataDemissao)
                .IsOptional();

 


            HasRequired(x => x.Empresa)
                .WithMany(x=>x.Colaboradores)
                .HasForeignKey(x => x.EmpresaId);

            HasRequired(x => x.Pessoa)
                .WithMany(x => x.Colaboradores)
                .HasForeignKey(x => x.PessoaId);

        }
    }
}
