using System;
using System.ComponentModel.DataAnnotations;

namespace ThiagoLemos.Web.MVC.Models
{
    public class EmpresaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "O nome não pode ter mais de 50 caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A razão social é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "A razão social não pode ter mais de 50 caracteres")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O CNPJ é um campo obrigatório")]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}