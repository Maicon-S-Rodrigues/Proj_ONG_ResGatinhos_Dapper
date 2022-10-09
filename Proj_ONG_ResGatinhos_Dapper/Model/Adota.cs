using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG_ResGatinhos_Dapper.Model
{
    public class Adota
    {
        #region Constant - SQL Commands

        #endregion
        public string PessoaCpf { get; set; }
        public string AnimalChip { get; set; }
        public string PessoaNome { get; set; }
        public string AnimalFamilia { get; set; }
        public string AnimalNome { get; set; }
        public string AnimalRaca { get; set; }
        public string AnimalSituacao { get; set; }

        public Adota(){}

        public override string ToString()
        {
            return " | CPF: " + this.PessoaCpf + " | Nome: " + this.PessoaNome + " |" +
                 "\n | CHIP do Pet: " + this.AnimalChip + " | Família Animal: " + this.AnimalFamilia + " |" +
                 "\n | Raça: " + this.AnimalRaca + " | Nome do Pet: |" + this.AnimalNome + " | Situação: " + this.AnimalSituacao + " |" +
                 "\n___________________________________________________________________________________________________\n";
        }
    }
}
