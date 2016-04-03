using System.Data.Entity.ModelConfiguration;
using ThiagoLemos.Domain;
using ThiagoLemos.Domain.Entities;

namespace ThiagoLemos.Infra.Configuration
{
    public class PessoaConfiguration : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.DataNascimento)
                .IsRequired();
                

            Property(x => x.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            Property(x => x.DataCadastro)
                .IsOptional();
        }
    }
}
