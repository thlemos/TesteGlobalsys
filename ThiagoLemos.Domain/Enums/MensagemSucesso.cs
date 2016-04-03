using System.ComponentModel;

namespace ThiagoLemos.Domain.Enums
{
    public enum MensagemSucesso
    {
        [Description("Registro criado com sucesso.")]
        Criar,

        [Description("Registro alterado com sucesso.")]
        Alterar,

        [Description("Registro excluído com sucesso.")]
        Excluir,

        [Description("Colaborador demitido com sucesso.")]
        Demitir,
    }
}