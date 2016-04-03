using System.ComponentModel;

namespace ThiagoLemos.Domain.Enums
{
    public enum MensagemErro
    {
        [Description("CPF já cadastrado.")]
        CPF_ja_cadastrado,

        [Description("CNPJ já cadastrado.")]
        CNPJ_ja_cadastrado,

        [Description("Essa pessoa já é colaborador dessa empresa.")]
        Pessoa_ja_colaborador_Empresa,

        [Description("Não é possível excluir a pessoa pois ela possui colaboradores cadastrados.")]
        PessoaColaboradoresCadastrados,

        [Description("Não é possível excluir a empresa pois ela possui colaboradores cadastrados.")]
        EmpresaColaboradoresCadastrados,
    }
}