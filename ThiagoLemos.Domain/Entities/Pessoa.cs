using System;
using System.Collections.Generic;

namespace ThiagoLemos.Domain.Entities
{
    public class Pessoa
    {
        public Pessoa()
        {
            
        }
        public Pessoa(string nome, DateTime dataNascimento, string cpf)
        {
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.Cpf = ValidaCpf(cpf); 
        }

        public int Id { get; set; }
        public string Nome { get; set; }


        public string Cpf { get; set ; }
 

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }


        public virtual ICollection<Colaborador> Colaboradores { get; set; }

        public bool PossuiColaboradores()
        {
            return Colaboradores.Count > 0;
        }


        private string ValidaCpf(string cpf)
        {
            cpf = RetiraPontos(cpf);
            if (cpf == "")
                throw new Exception("CPF vazio");
            if (!IsCpf(cpf))
            {
                throw new Exception("CPF Inválido");
            }
            return cpf;
        }



        //private bool ValidarValorCNPJ(string cnpj)
        //{
        //    return false; // todo Validacao de CNPJ
        //}

        
        private bool IsCpf(string cpf)
        {
            while (cpf.Length < 11)
                cpf = "0" + cpf;

            var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            var resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            var digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto;
            return cpf.EndsWith(digito);
        }
    


        private string RetiraPontos(string cpf)
        {
            var valor = cpf.Replace(".", "").Replace("-", "").Replace("/", "");
            return valor;
        }
    }
}
