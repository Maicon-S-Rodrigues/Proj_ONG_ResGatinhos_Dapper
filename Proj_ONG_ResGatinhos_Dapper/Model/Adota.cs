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
        //mostrar todos adotantes com seus respectivos pets
        public readonly static string SelectAll = "SELECT Pessoa.CPF, Pessoa.Nome, Animal.CHIP, Animal.Familia, Animal.Nome, Animal.Raca, Animal.Situacao " +
                                                  "FROM Adota " +

                                                  "RIGHT JOIN Pessoa " +

                                                  "ON(Pessoa.CPF = Adota.CPF) " +

                                                  "RIGHT JOIN Animal " +

                                                  "ON(Animal.CHIP = Adota.CHIP) " +

                                                  "WHERE Animal.Situacao = 'ADOTADO'";

        //mostrar todos os PETS adotados por um CPF especifico
        public readonly static string SelectAllAdotadosCpf = "SELECT Pessoa.CPF, Pessoa.Nome, Animal.CHIP, Animal.Familia, Animal.Nome, Animal.Raca, Animal.Situacao " +
                                                             "FROM Adota " +

                                                             "RIGHT JOIN Pessoa " +

                                                             "ON(Pessoa.CPF = Adota.CPF) " +

                                                             "RIGHT JOIN Animal " +

                                                             "ON(Animal.CHIP = Adota.CHIP) " +

                                                             "WHERE Pessoa.CPF = @Cpf";


        public readonly static string Insert = "INSERT INTO Adota VALUES(@Cpf, @Chip)";

        public readonly static string DeleteAdocao = "DELETE FROM Adota WHERE CHIP = @Chip";



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
