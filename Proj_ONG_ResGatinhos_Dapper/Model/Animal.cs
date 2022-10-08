using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG_ResGatinhos_Dapper.Model
{
    public class Animal
    {
        #region Constant - SQL Commands
        public readonly static string Insert = "INSERT INTO Animal (Familia, Raca, Nome, Sexo) " +
                                               "VALUES(@Familia, @Raca, @Nome, @Sexo)";

        public readonly static string Exists = "SELECT CHIP FROM Animal WHERE CHIP = @Chip";

        public readonly static string UpdateFamilia = "UPDATE Animal SET Familia = @Familia WHERE CHIP = @Chip";

        public readonly static string UpdateRaca = "UPDATE Animal SET Raca = @Raca WHERE CHIP = @Chip";

        public readonly static string UpdateSexo = "UPDATE Animal SET Sexo = @Sexo WHERE CHIP = @Chip";

        public readonly static string UpdateNome = "UPDATE Animal SET Nome = @Nome WHERE CHIP = @Chip";

        public readonly static string SelectDisponiveis = "SELECT CHIP, Familia, Raca, Nome, Sexo, Situacao FROM Animal WHERE Situacao = 'DISPONIVEL'";

        public readonly static string SelectAdotados = "SELECT CHIP, Familia, Raca, Nome, Sexo, Situacao FROM Animal WHERE Situacao = 'ADOTADO'";

        public readonly static string SelectOne = "SELECT CHIP, Familia, Raca, Nome, Sexo, Situacao FROM Animal WHERE CHIP = @Chip";
        #endregion
        
        public int Chip { get; set; }
        public string Familia { get; set; }
        public string Raca { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Situacao { get; set; }

        public Animal(){}
        public Animal(string familia, string raca, string nome, string sexo, string situacao)
        {
            this.Familia = familia;
            this.Raca = raca;
            this.Nome = nome;
            this.Sexo = sexo;
            this.Situacao = situacao;
        }

        public override string ToString()
        {
            return " | CHIP: " + this.Chip + " | Familia: " + this.Familia + " | Raça: " + this.Raca +
                 "\n | Nome: " + this.Nome + " | Sexo: " + this.Sexo + " | Situação: " + this.Situacao + " |" +
                 "\n___________________________________________________________________________________________________\n";
        }

    }
}
