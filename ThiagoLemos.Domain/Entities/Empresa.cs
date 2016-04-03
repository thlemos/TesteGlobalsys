using System;
using System.Collections.Generic;


namespace ThiagoLemos.Domain.Entities
{
    public class Empresa
    {
        public Empresa()
        {
            
        }
        public Empresa(string nome, string razaoSocial, string cnpj)
        {
            // TODO: Complete member initialization
            this.Nome = nome;
            this.RazaoSocial = razaoSocial;
            this.Cnpj = ValidaCnpj(cnpj);
        }

        public int Id { get; set; }

        public string Cnpj { get; set; }


        public string Nome { get; set; }

        public string RazaoSocial { get; set; }

        public DateTime DataCadastro { get; set; }

        public virtual ICollection<Colaborador> Colaboradores { get; set; }
        
        private string ValidaCnpj(string cnpj)
        {
            cnpj = RetiraPontos(cnpj);
            if (cnpj == "")
                throw new Exception("CNPJ vazio");
            if (!IsCnpj(cnpj))
            {
                throw new Exception("CNPJ Inválido");
            }
            return cnpj;
        }

        
        private bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;

            int resto;

            string digito;

            string tempCnpj;

            cnpj = cnpj.Trim();

            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)

                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;

            for (int i = 0; i < 12; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;

            soma = 0;

            for (int i = 0; i < 13; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }


        private string RetiraPontos(string cnpj)
        {
            var xxx = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            return xxx;
        }

        public bool PossuiColaboradores()
        {
            return Colaboradores.Count > 0;
        }
        
    }
}
