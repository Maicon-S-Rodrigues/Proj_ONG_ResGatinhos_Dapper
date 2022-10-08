using Proj_ONG_ResGatinhos_Dapper.Model;
using Proj_ONG_ResGatinhos_Dapper.Services;
using System;
using System.Collections.Generic;

namespace Proj_ONG_ResGatinhos_Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region teste insert e selec all
            //////////////////---TESTE---///////////////////////////////////////
            //Console.WriteLine("Start");

            //Pessoa adotante = new Pessoa() // add um
            //{
            //    Cpf = "47931004817",

            //    Nome = "MAICON RODRIGUES",

            //    Sexo = "M",

            //    Data_Nascimento = DateTime.Parse("11/05/1999"),

            //    Telefone = "16 988144127",

            //    Estado = "SP",

            //    Cidade = "Araraquara",
            //    Bairro = "Jd.Silvestre",
            //    Rua = "Jose Segantini",
            //    Numero = 161,
            //    Complemento = ""
            //};
            //new PessoaServices().Add(adotante);

            //adotante = new Pessoa() // add dois
            //{
            //    Cpf = "21673370861",

            //    Nome = "THAIS VILASBOAS",

            //    Sexo = "F",

            //    Data_Nascimento = DateTime.Parse("25/11/1999"),

            //    Telefone = "16 988623563",

            //    Estado = "SP",

            //    Cidade = "Araraquara",
            //    Bairro = "Jd.Cruzeiro do Sul",
            //    Rua = "Jesuino Lopes",
            //    Numero = 1001,
            //    Complemento = ""
            //};
            //new PessoaServices().Add(adotante);

            //new PessoaServices().GetAll().ForEach(x => Console.WriteLine(x));
            /////////////////////////////////////////////////////////////////////
            #endregion

            #region Teste SELECT ONE pelo CPF
            //string cpf = "21670873361";
            //Pessoa thais = new PessoaServices().Get(cpf);
            //Console.WriteLine(thais.ToString());
            #endregion

            #region UPDATE ONE pelo CPF

            #region update Nome
            //string cpfAlterar = "47931004817";  //// se o cpf informado for existente, retorna uma linha afetada e confirma a alteração.
            //                                   //// se o cpf estiver errado, retorna nenhuma linha afetada e retorna que a alteração não aconteceu.
            //string novoNome = "Maic";

            //bool deuCerto = new PessoaServices().UpdateNome(cpfAlterar, novoNome);
            //if (deuCerto == true)
            //{
            //    Console.WriteLine("Deu certo");
            //}
            //else
            //{
            //    Console.WriteLine("Não alterou");
            //}
            #endregion

            #region update Sexo
            //string cpfAlterar = "47931004817";

            //string novoSexo = "F";

            //bool deuCerto = new PessoaServices().UpdateSexo(cpfAlterar, novoSexo);
            //if (deuCerto == true)
            //{
            //    Console.WriteLine("Deu certo");
            //}
            //else
            //{
            //    Console.WriteLine("Não alterou");
            //}
            #endregion

            #region update Telefone
            //string cpfAlterar = "47931004817";

            //string novoTelefone = "169976144127";

            //bool deuCerto = new PessoaServices().UpdateTelefone(cpfAlterar, novoTelefone);
            //if (deuCerto == true)
            //{
            //    Console.WriteLine("Deu certo");
            //}
            //else
            //{
            //    Console.WriteLine("Não alterou");
            //}
            #endregion

            #region update DataNascimento
            string cpfAlterar = "47931004817";

            DateTime novaDataNasc = DateTime.Parse("25/05/1995");

            bool deuCerto = new PessoaServices().UpdateDataNascimento(cpfAlterar, novaDataNasc);
            if (deuCerto == true)
            {
                Console.WriteLine("Deu certo");
            }
            else
            {
                Console.WriteLine("Não alterou");
            }
            #endregion

            #region update Endereco

            #endregion

            #endregion
        }
    }
}
