using Proj_ONG_ResGatinhos_Dapper.Model;
using Proj_ONG_ResGatinhos_Dapper.Services;
using System;
using System.Collections.Generic;

namespace Proj_ONG_ResGatinhos_Dapper
{
    internal class Program
    {
        #region MainView
        static void TelaInicial()
        {
            do
            {
                int opc;
                Console.Clear();
                Console.WriteLine(" Bem Vindo à ResGatinhos!");
                Console.WriteLine(" Escolha a Opção desejada para continuar:\n");
                Console.Write(" 1 - ADOTANTES\n");
                Console.Write(" 2 - PETS\n");
                Console.Write(" 3 - Area de ADOÇÃO\n");
                Console.Write(" 0 - Encerrar Sessão\n");
                try
                {
                    opc = int.Parse(Console.ReadLine());
                    switch (opc)
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine("\n\n\n\t\t\tObrigado pela sua Cãopanhia!!!\n\t\t\tContinue sempre com os ResGatinhos!!!\n\n\n");
                            Console.WriteLine("\t\t\t......Encerrando Sessão......");
                            Environment.Exit(0);
                            break;

                        case 1:
                            TelaAdotantes();
                            break;

                        case 2:
                            TelaPets();
                            break;

                        case 3:
                            TelaAdocao();
                            break;

                        default:
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Escolha um valor numérico que represente a opção desejada!\n");
                    Pausa();
                }
            } while (true);
        }
        static void TelaAdotantes()
        {
            do
            {
                int opc;
                Console.Clear();
                Console.WriteLine("ADOTANTES\n");
                Console.WriteLine(" O que deseja fazer?");
                Console.WriteLine(" 1 - Ver todos Cadastrados");
                Console.WriteLine(" 2 - Cadastrar um Novo");
                Console.WriteLine(" 3 - Editar um Cadastro já Existente");
                Console.WriteLine(" 4 - Ver Histórico de Adoção de um já Cadastrado"); // <<<<<<<< ????
                Console.WriteLine(" 0 - Voltar");
                try
                {
                    opc = int.Parse(Console.ReadLine());
                    switch (opc)
                    {
                        case 0:
                            TelaInicial();
                            break;

                        case 1:
                            Console.Clear();//recebe a quantidade total de adotantes cadastrados e ja verifica se existe ou não cadastros
                            if (new PessoaServices().GetAll().Count == 0) Console.WriteLine("\n\nNão há nenhum Adodante Cadastrado!\n");

                            //se a lista não esta vazia, imprime todos adotantes que encontrou cadastrado
                            else new PessoaServices().GetAll().ForEach(x => Console.WriteLine(x)); 
                            Pausa();
                            break;

                        case 2:
                            CadastrarAdotante();
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("\nEDITAR ADOTANTES\n");
                            Console.Write("\nInforme o 'CPF' do Adotante que deseja editar: ");
                            string cpfEditar = Console.ReadLine();
                            //EditarAdotante(cpfEditar);
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("ADOTANTES\n");
                            Console.Write("\nInforme o 'CPF' do Adotante para ver quais Animais ele adotou: ");
                            string cpfPesquisa = Console.ReadLine();
                            //MostrarAnimaisAdotadosPeloCPF(cpfPesquisa);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            } while (true);
        }
        #region Functions_Adotantes
        static void CadastrarAdotante()
        {
            try
            {
                string cpf, nome, sexo, telefone, cidade, estado, bairro, rua, complemento;
                DateTime dataNascimento;
                int numero;

                Console.Clear();
                Console.WriteLine("CADASTRO DE ADOTANTE\n\n");
                Console.Write("\nInforme o CPF para começar: ");
                cpf = Console.ReadLine();

                if (new PessoaServices().Exists(cpf) == true)
                {
                    Console.WriteLine("\n[-- Este CPF já esta Cadastrado! --]\n");
                    Pausa();
                    return;
                }

                Console.Write("\nNome: ");
                nome = Console.ReadLine();

                bool flag = false;
                do
                {
                    Console.Write("\nDigite [- F -] para Feminino, [- M -] para Masculino ou [- N -] caso Não queira informar");
                    Console.Write("\nSexo: ");
                    sexo = Console.ReadLine().ToUpper();
                    if (sexo.ToUpper() == "F" || sexo.ToUpper() == "M" || sexo.ToUpper() == "N")
                    {
                        flag = true;
                        //break;
                    }
                } while (flag == false);

                Console.Write("\nData de Nascimento (dd/MM/yyy): ");
                dataNascimento = LerData();

                Console.Write("\nTelefone: ");
                telefone = Console.ReadLine();

                Console.Write("\n\nENDEREÇO [-- Cidade, Estado, Bairro, Rua, Número, Complemento --]");
                Console.Write("\nCidade: ");
                cidade = Console.ReadLine();

                Console.Write("\nEstado (U-F): ");
                estado = Console.ReadLine();

                Console.Write("\nBairro: ");
                bairro = Console.ReadLine();

                Console.Write("\nRua: ");
                rua = Console.ReadLine();

                Console.Write("\nNúmero: ");
                numero = LerNumero();

                Console.Write("\nComplemento: ");
                complemento = Console.ReadLine();

                Pessoa adotante = new (cpf, nome, sexo, dataNascimento, telefone, estado, cidade, bairro, rua, numero, complemento);

                new PessoaServices().Add(adotante);

                Console.Clear();
                Console.WriteLine("\nCadastro Realizado com Sucesso!");
                Pausa();
            }
            catch (Exception e)
            {
                Console.WriteLine("Desculpa... Houve um Erro Inesperado durante o Cadastro.\nTente Novamente.\n\n<<<" + e + ">>>");
            }
        }
        #endregion
        static void TelaPets()
        {

        }
        static void TelaAdocao()
        {

        }
        #endregion

        #region Utility
        static void Pausa()
        {
            Console.WriteLine("Aperte [- ENTER -] para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        static DateTime LerData()
        {
            do
            {
                try
                {
                    DateTime data = DateTime.Parse(Console.ReadLine());
                    return data;
                }
                catch
                {
                    Console.WriteLine("Data Inválida!");
                }
            } while (true);
        }
        static int LerNumero()
        {
            do
            {
                try
                {
                    int numero = int.Parse(Console.ReadLine());
                    return numero;
                }
                catch
                {
                    Console.WriteLine("Número inválido!");
                }
            } while (true);
        }
        #endregion

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
            //string cpfAlterar = "47931004817";

            //DateTime novaDataNasc = DateTime.Parse("25/05/1995");

            //bool deuCerto = new PessoaServices().UpdateDataNascimento(cpfAlterar, novaDataNasc);
            //if (deuCerto == true)
            //{
            //    Console.WriteLine("Deu certo");
            //}
            //else
            //{
            //    Console.WriteLine("Não alterou");
            //}
            #endregion

            #region update Endereco
            //string cpfAlterar = "47931004817";
            //string cidade, estado, bairro, rua, complemento;
            //int numero;

            //cidade = "Ribeirao Preto";
            //estado = "RJ";
            //bairro = "Santa Terezinha";
            //rua = "via são bento";
            //numero = 3002;
            //complemento = "";

            //bool deuCerto = new PessoaServices().UpdateEndereco(cpfAlterar, cidade, estado, bairro, rua, numero, complemento);
            //if (deuCerto == true)
            //{
            //    Console.WriteLine("Deu certo");
            //}
            //else
            //{
            //    Console.WriteLine("Não alterou");
            //}
            #endregion

            #endregion

            TelaInicial();
        }
    }
}
