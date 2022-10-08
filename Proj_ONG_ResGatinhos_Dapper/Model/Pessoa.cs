using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG_ResGatinhos_Dapper.Model
{
    public class Pessoa
    {
		#region Constant - SQL Commands
		#endregion

		public string Cpf { get; set; }
		public string Nome { get; set; }
		public string Sexo { get; set; }
		public DateTime Data_Nascimento { get; set; }
		public string Telefone { get; set; }
		public string Estado { get; set; }
		public string Cidade { get; set; }
		public string Bairro { get; set; }
		public string Rua { get; set; }
		public int Numero { get; set; }
		public string Complemento { get; set; }

        public override string ToString()
        {
			return " | CPF: " + this.Cpf + " | Nome: " + this.Nome + " | Sexo: " + this.Sexo + " | Data de Nascimento: " + this.Data_Nascimento +
				   " | Telefone: " + this.Telefone + 
				   "\n | Endereço: |" +
                   "\n | " + this.Cidade + ", " + this.Estado + " |" +
				   "\n | " + this.Rua + ", " + this.Numero + " |" +
				   "\n | Complemento: " + this.Complemento + 
				   "\n\n_________________________________________________________________________________________________________________________";
        }

    }
}
