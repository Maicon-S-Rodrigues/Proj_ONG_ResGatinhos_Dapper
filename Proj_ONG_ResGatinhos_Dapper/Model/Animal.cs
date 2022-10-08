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
