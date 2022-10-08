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
        static void TelaAdotantes() // colocar o "ver historico de animais adotados? <<---?
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
                            if (new PessoaServices().Exists(cpfEditar) == false)
                            {
                                Console.WriteLine("\n[-- Este CPF não esta Cadastrado! --]\n");
                                Pausa();
                                return;
                            }
                            EditarAdotante(cpfEditar);
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
        static void EditarAdotante(string cpfEditar)
        {
            do
            {
                int opc;
                Console.Clear();
                Console.WriteLine("EDITAR ADOTANTE: ");
                Pessoa adotante = new PessoaServices().Get(cpfEditar);
                Console.WriteLine(adotante.ToString());
                Console.WriteLine(" O que deseja fazer?");
                Console.WriteLine(" 1 - Editar Nome");
                Console.WriteLine(" 2 - Editar Telefone");
                Console.WriteLine(" 3 - Editar Sexo");
                Console.WriteLine(" 4 - Editar Endereço");
                Console.WriteLine(" 5 - Editar Data de Nascimento");
                Console.WriteLine(" 0 - Voltar");
                try
                {
                    opc = int.Parse(Console.ReadLine());
                    switch (opc)
                    {
                        case 0:
                            TelaAdotantes();
                            break;

                        case 1:
                            Console.WriteLine("\nAlterar Nome:");
                            Console.Write("Informe o Novo Nome a Ser Gravado: ");
                            string novoNome = Console.ReadLine();

                            if (new PessoaServices().UpdateNome(cpfEditar, novoNome) == true) Console.WriteLine("\nNome Alterado!");
                            else Console.WriteLine("\nDesculpe, Não foi possível realizar essa alteração.");
                            Pausa();
                            break;

                        case 2:
                            Console.WriteLine("\nAlterar Telefone:");
                            Console.Write("Informe o Novo Telefone a Ser Gravado: ");
                            string novoTelefone = Console.ReadLine();

                            if (new PessoaServices().UpdateTelefone(cpfEditar, novoTelefone) == true) Console.WriteLine("\nTelefone Alterado!");
                            else Console.WriteLine("\nDesculpe, Não foi possível realizar essa alteração.");
                            Pausa();
                            break;

                        case 3: //sexo
                            Console.WriteLine("\nAlterar Sexo:");
                            Console.Write("Informe o Novo Sexo a Ser Gravado: ");
                            bool flag = false;
                            string novoSexo;
                            do
                            {
                                Console.Write("\nDigite [- F -] para Feminino, [- M -] para Masculino ou [- N -] caso Não queira informar");
                                Console.Write("\nSexo: ");
                                novoSexo = Console.ReadLine().ToUpper();
                                if (novoSexo.ToUpper() == "F" || novoSexo.ToUpper() == "M" || novoSexo.ToUpper() == "N")
                                {
                                    flag = true;
                                    break;
                                }
                            } while (flag == false);

                            if (new PessoaServices().UpdateSexo(cpfEditar, novoSexo) == true) Console.WriteLine("\nSexo Alterado!");
                            else Console.WriteLine("\nDesculpe, Não foi possível realizar essa alteração.");
                            Pausa();
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("\nAlterar Endereço:");
                            Console.Write("\n[-- Cidade, Estado, Bairro, Rua, Número, Complemento --]");
                            Console.Write("\nCidade: ");
                            string cidade = Console.ReadLine();

                            Console.Write("\nEstado (U-F): ");
                            string estado = Console.ReadLine();

                            Console.Write("\nBairro: ");
                            string bairro = Console.ReadLine();

                            Console.Write("\nRua: ");
                            string rua = Console.ReadLine();

                            Console.Write("\nNúmero: ");
                            int numero = LerNumero();

                            Console.Write("\nComplemento: ");
                            string complemento = Console.ReadLine();

                            if (new PessoaServices().UpdateEndereco(cpfEditar, cidade, estado, bairro, rua, numero, complemento) == true) Console.WriteLine("\nEndereço Alterado!");
                            else Console.WriteLine("\nDesculpe, Não foi possível realizar essa alteração.");
                            Pausa();
                            break;

                        case 5:
                            Console.WriteLine("\nAlterar Data de Nascimento:");
                            Console.Write("Informe a Nova Data de Nascimento a Ser Gravada: ");
                            DateTime novaDataNascimento = LerData();

                            if (new PessoaServices().UpdateDataNascimento(cpfEditar, novaDataNascimento) == true) Console.WriteLine("\nData de Nascimento Alterada!");
                            else Console.WriteLine("\nDesculpe, Não foi possível realizar essa alteração.");
                            Pausa();
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
        #endregion
        static void TelaPets()
        {
            do
            {
                int opc;
                Console.Clear();
                Console.WriteLine("PETS\n");
                Console.WriteLine(" O que deseja fazer?");
                Console.WriteLine(" 1 - Cadastrar um novo PET");
                Console.WriteLine(" 2 - Editar os dados de um já cadastrado");
                Console.WriteLine(" 3 - Ver a Lista de Pets Disponíveis para Adoção");
                Console.WriteLine(" 4 - Ver a Lista de Pets já Adotados");
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
                            CadastrarPet();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("\nEDITAR PETS\n");
                            Console.Write("\nInforme o número do 'CHIP' do Pet que deseja editar: ");
                            string chip = Console.ReadLine();
                            EditarPet(chip);
                            break;

                        case 3:
                            //MostrarPetsDisponiveis(); //mostrar todos filhtrando pelo campo situacao como "DISPONIVEL"
                            break;

                        case 4:
                            //MostrarPetsAdotados(); //mostrar todos filhtrando pelo campo situacao como "ADOTADO"
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
        #region Functions_Pets
        static void CadastrarPet()
        {
            try
            {
                string familia, raca, nome, sexo;

                Console.Clear();
                Console.WriteLine("CADASTRO DE PET\n\n");

                Console.Write("\nA qual Família Animal ele/a pertence?\n(Gato, Cachorro, Passaro, etc...): ");
                familia = Console.ReadLine();

                Console.Write("\nQual a Raça?");
                raca = Console.ReadLine();

                Console.Write("\nNome: ");
                nome = Console.ReadLine();

                bool flag = false;
                do
                {
                    Console.Write("\nDigite [- F -] para Feminino, [- M -] para Masculino ou [- N -] caso Não saiba informar no momento");
                    Console.Write("\nSexo: ");
                    sexo = Console.ReadLine().ToUpper();
                    if (sexo.ToUpper() == "F" || sexo.ToUpper() == "M" || sexo.ToUpper() == "N")
                    {
                        flag = true;
                    }
                } while (flag == false);

                Animal pet = new(familia, raca, nome, sexo);

                new AnimalServices().Add(pet);

                Console.Clear();
                Console.WriteLine("\nCadastro Realizado com Sucesso!");
                Pausa();
            }
            catch (Exception e)
            {
                Console.WriteLine("Desculpa... Houve um Erro Inesperado durante o Cadastro.\nTente Novamente.\n\n<<<" + e + ">>>");
            }
        }
        static void EditarPet(string chipEditar)
        {

        }
        #endregion
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
            TelaInicial();
        }
    }
}
