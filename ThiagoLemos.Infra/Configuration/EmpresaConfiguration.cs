using System.Data.Entity.ModelConfiguration;
using ThiagoLemos.Domain.Entities;

namespace ThiagoLemos.Infra.Configuration
{
    public class EmpresaConfiguration : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.RazaoSocial)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Cnpj)
                .IsRequired()
                .HasMaxLength(14);

            Property(x => x.DataCadastro)
                .IsRequired();

        }
    }
}
