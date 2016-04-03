using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ThiagoLemos.Domain.Entities;
using ThiagoLemos.Domain.Enums;

namespace ThiagoLemos.Web.MVC.Models
{
    public class ColaboradorViewModel
    {
        public int Id { get; set; }

        
        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }

        [Display(Name = "Pessoa")]
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "O cargo é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "O cargo não pode ter mais de 50 caracteres")]
        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "O salário é um campo obrigatório")]
        [Range(0,double.MaxValue-1,ErrorMessage = "O salário não é um valor válido.")]
        [Display(Name = "Salário")]
        public double Salario { get; set; }

        [Display(Name = "Status")]
        public Status Status { get; set; }

        
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Demissão")]
        public DateTime? DataDemissao { get; set; }


        public Pessoa Pessoa { get; set; }
        public Empresa Empresa { get; set; }


        public List<Pessoa> ListaPessoas { get; set; }
        public List<Empresa> ListaEmpresas { get; set; }
        
    }
}