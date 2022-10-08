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
		public readonly static string Insert = "INSERT INTO Pessoa (CPF, Nome, Sexo, Data_Nascimento, Telefone, Estado, Cidade, Bairro, Rua, Numero, Complemento)" +
											   "VALUES(@Cpf, @Nome, @Sexo, @Data_Nascimento, @Telefone, @Estado, @Cidade, @Bairro, @Rua, @Numero, @Complemento)";

		public readonly static string UpdateNome = "UPDATE Pessoa SET Nome = @Nome WHERE CPF = @Cpf"; // <----------------------------------

		public readonly static string UpdateTelefone = "UPDATE Pessoa SET Telefone = @Telefone WHERE CPF = @Cpf";

		public readonly static string UpdateSexo = "UPDATE Pessoa SET Sexo = @Sexo WHERE CPF = @Cpf";

		public readonly static string UpdateDataNascimento = "UPDATE Pessoa SET Data_Nascimento = @Data_Nascismento WHERE CPF = @Cpf";

		public readonly static string UpdateEndereco = "UPDATE Pessoa SET Cidade = @Cidade, Estado = @Estado, Bairro = @Bairro, Rua = @Rua, " +
													   "Numero = @Numero, Complemento = @Complemento WHERE CPF = @Cpf";

		public readonly static string SelectAll = "SELECT CPF, Nome, Sexo, Data_Nascimento, Telefone, Cidade, Estado, Bairro, Rua, Numero, Complemento FROM Pessoa";

		public readonly static string SelectOne = "SELECT CPF, Nome, Sexo, Data_Nascimento, Telefone, Cidade, Estado, Bairro, Rua, Numero, Complemento FROM Pessoa where CPF = @Cpf"; //testar
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

		public Pessoa()
        {

        }
        public override string ToString()
        {
			return " | CPF: " + this.Cpf + " | Nome: " + this.Nome + " | Sexo: " + this.Sexo + 
				 "\n | Data de Nascimento: " + this.Data_Nascimento.ToShortDateString() +
				   " | Telefone: " + this.Telefone + 
			     "\n | Endereço: |" +
                 "\n | " + this.Cidade + ", " + this.Estado + " |" +
				 "\n | " + this.Rua + ", " + this.Numero + " |" +
				 "\n | Complemento: " + this.Complemento + 
				 "\n___________________________________________________________________________________________________\n";
        }

    }
}
