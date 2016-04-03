using System;
using System.ComponentModel.DataAnnotations;
using ThiagoLemos.Web.MVC.Helpers;

namespace ThiagoLemos.Web.MVC.Models
{
    public class PessoaViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é um campo obrigatório")]
        [Display(Name = "Nome")]
        [StringLength(50,ErrorMessage = "O nome não pode ter mais de 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é um campo obrigatório")]
        [DisplayFormat(DataFormatString = "{0:###.###.###-##}", ApplyFormatInEditMode = true)]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "A data de nascimento é um campo obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [ValidateDateRange]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        public DateTime? DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; } 
    }
}