using Proj_ONG_ResGatinhos_Dapper.Model;
using Proj_ONG_ResGatinhos_Dapper.Services;
using System;

namespace Proj_ONG_ResGatinhos_Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //////////////////---TESTE---///////////////////////////////////////
            Console.WriteLine("Start");

            Pessoa adotante = new Pessoa() // add um
            {
                Cpf = "47931004817",

                Nome = "MAICON RODRIGUES",

                Sexo = "M",

                Data_Nascimento = DateTime.Parse("11/05/1999"),

                Telefone = "16 988144127",

                Estado = "SP",

                Cidade = "Araraquara",
                Bairro = "Jd.Silvestre",
                Rua = "Jose Segantini",
                Numero = 161,
                Complemento = ""
            };
            new PessoaServices().Add(adotante);

            adotante = new Pessoa() // add dois
            {
                Cpf = "21673370861",

                Nome = "THAIS VILASBOAS",

                Sexo = "F",

                Data_Nascimento = DateTime.Parse("25/11/1999"),

                Telefone = "16 988623563",

                Estado = "SP",

                Cidade = "Araraquara",
                Bairro = "Jd.Cruzeiro do Sul",
                Rua = "Jesuino Lopes",
                Numero = 1001,
                Complemento = ""
            };
            new PessoaServices().Add(adotante);

            new PessoaServices().GetAll().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("Uffa");


            /////////////////////////////////////////////////////////////////////

        }
    }
}
