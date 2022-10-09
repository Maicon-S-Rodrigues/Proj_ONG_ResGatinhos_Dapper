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
                Console.WriteLine("\n Bem Vindo à ResGatinhos!");
                Console.WriteLine(" Escolha a Opção desejada para continuar:\n");
                Console.Write(" 1 - Adotantes\n");
                Console.Write(" 2 - Pets\n");
                Console.Write(" 3 - Area de Adoções\n");
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
                Console.WriteLine("\n RESGATINHOS - ADOTANTES\n");
                Console.WriteLine(" O que deseja fazer?");
                Console.WriteLine(" 1 - Ver todos Cadastrados");
                Console.WriteLine(" 2 - Cadastrar um Novo");
                Console.WriteLine(" 3 - Editar um Cadastro já Existente");
                Console.WriteLine(" 4 - Ver Histórico de Adoção de um já Cadastrado");
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
                            Console.WriteLine("\nRESGATINHOS - EDITAR ADOTANTES\n");
                            Console.Write("\nInforme o 'CPF' do Adotante que deseja editar: ");
                            string cpfEditar = Console.ReadLine();
                            if (new PessoaServices().Exists(cpfEditar) == false)
                            {
                                Console.WriteLine("\n[-- Este CPF não esta Cadastrado ou não é valido! --]\n");
                                Pausa();
                                return;
                            }
                            EditarAdotante(cpfEditar);
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("\nRESGATINHOS - ADOTANTES\n");
                            Console.Write("\nInforme o CPF do Adotante para ver quais Animais ele tem adotado: ");
                            string cpfPesquisar = Console.ReadLine();
                            if (new PessoaServices().Exists(cpfPesquisar) == false)
                            {
                                Console.WriteLine("\n[-- Este CPF não esta Cadastrado ou não é valido! --]\n");
                                Pausa();
                                return;
                            }
                            Console.Clear();
                            if (new AdotaServices().GetAllAdotadosCpf(cpfPesquisar).Count == 0) Console.WriteLine("\n\nNão há Nenhum Pet adotado por este Adotante!\n");

                            //se a lista não esta vazia, imprime todos
                            else new AdotaServices().GetAllAdotadosCpf(cpfPesquisar).ForEach(x => Console.WriteLine(x));
                            Pausa();
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
                Console.WriteLine("\nCADASTRO DE ADOTANTE\n\n");
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

                Pessoa adotante = new(cpf, nome, sexo, dataNascimento, telefone, estado, cidade, bairro, rua, numero, complemento);

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
                Console.WriteLine("\nEDITAR ADOTANTE: ");
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
                Console.WriteLine("\n RESGATINHOS - PETS\n");
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
                            string chipEditar = Console.ReadLine();
                            if (new AnimalServices().Exists(chipEditar) == false)
                            {
                                Console.WriteLine("\n[-- Este CHIP não esta Cadastrado ou não é valido! --]\n");
                                Pausa();
                                return;
                            }
                            EditarPet(chipEditar);
                            break;

                        case 3:
                            Console.Clear();
                            if (new AnimalServices().GetAllDisponiveis().Count == 0) Console.WriteLine("\n\nNão há nenhum Pet Disponível para Adoção!\n");
                            //mostrar todos filhtrando pelo campo situacao como "DISPONIVEL"
                            else new AnimalServices().GetAllDisponiveis().ForEach(x => Console.WriteLine(x));
                            Pausa();
                            break;

                        case 4:
                            Console.Clear();
                            if (new AnimalServices().GetAllAdotados().Count == 0) Console.WriteLine("\n\nNão há nenhum registro sobre Pets Adotados!\n");
                            //mostrar todos filhtrando pelo campo situacao como "ADOTADO"
                            else new AnimalServices().GetAllAdotados().ForEach(x => Console.WriteLine(x));
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
        #region Functions_Pets
        static void CadastrarPet()
        {
            try
            {
                string familia, raca, nome, sexo;

                Console.Clear();
                Console.WriteLine("\nCADASTRO DE PET\n\n");

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
            do
            {
                int opc;
                Console.Clear();
                Console.WriteLine("\nEDITAR PET: ");
                Animal animal = new AnimalServices().Get(chipEditar);
                Console.WriteLine(animal.ToString());
                Console.WriteLine(" O que deseja fazer?");
                Console.WriteLine(" 1 - Editar Família Animal");
                Console.WriteLine(" 2 - Editar Raça");
                Console.WriteLine(" 3 - Editar Sexo");
                Console.WriteLine(" 4 - Editar Nome");
                Console.WriteLine(" 0 - Voltar");
                try
                {
                    opc = int.Parse(Console.ReadLine());
                    switch (opc)
                    {
                        case 0:
                            TelaPets();
                            break;

                        case 1:
                            Console.WriteLine("\nAlterar Família Animal Pertencente:");
                            Console.Write("Informe a Família Animal a Ser Gravada: ");
                            string novaFamilia = Console.ReadLine();

                            if (new AnimalServices().UpdateFamilia(chipEditar, novaFamilia) == true) Console.WriteLine("\nFamília Animal Alterada!");
                            else Console.WriteLine("\nDesculpe, Não foi possível realizar essa alteração.");
                            Pausa();
                            break;

                        case 2:
                            Console.WriteLine("\nAlterar Raça Pertencente:");
                            Console.Write("Informe a Raça a Ser Gravada: ");
                            string novaRaca = Console.ReadLine();

                            if (new AnimalServices().UpdateRaca(chipEditar, novaRaca) == true) Console.WriteLine("\nRaça do Pet Alterada!");
                            else Console.WriteLine("\nDesculpe, Não foi possível realizar essa alteração.");
                            Pausa();
                            break;

                        case 3:
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

                            if (new AnimalServices().UpdateSexo(chipEditar, novoSexo) == true) Console.WriteLine("\nSexo do Pet Alterado!");
                            else Console.WriteLine("\nDesculpe, Não foi possível realizar essa alteração.");
                            Pausa();
                            break;

                        case 4:
                            Console.WriteLine("\nAlterar Nome:");
                            Console.Write("Informe o Novo Nome a Ser Gravado para o Pet: ");
                            string novoNome = Console.ReadLine();

                            if (new AnimalServices().UpdateNome(chipEditar, novoNome) == true) Console.WriteLine("\nNome do Pet Alterado!");
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
        static void TelaAdocao()
        {
            do
            {
                int opc;
                Console.Clear();
                Console.WriteLine("\n RESGATINHOS - ADOÇÕES\n");
                Console.WriteLine(" O que deseja fazer?");
                Console.WriteLine(" 1 - Nova Adoção");
                Console.WriteLine(" 2 - Desvincular uma Adoção");
                Console.WriteLine(" 3 - Ver a Lista de Adotantes e seus respectivos Pets");
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
                            CadastrarAdocao();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("\n DESVINCULAR UMA ADOÇÃO\n\n");

                            Console.Write(" Informe o CHIP do Pet que deseja desvincular a Adoção: ");
                            string chip = Console.ReadLine();
                            if (new AnimalServices().Exists(chip) == false)
                            {
                                Console.WriteLine("\n[-- Este CHIP não esta Cadastrado ou não é valido! --]\n");
                                Pausa();
                                break;
                            }
                            if (new AnimalServices().ExistsDisponivel(chip) == true)
                            {
                                Console.WriteLine("\n[-- Este Pet já está Disponível, sem nenhum vínculo de Adoção! --]\n");
                                Pausa();
                                break;
                            }

                            bool flag = false;
                            string confirma;
                            Console.WriteLine("\n Você tem Certeza que deseja Desvincular essa Adoção?");
                            Console.WriteLine("\n Pressione [-- S --]->Sim");
                            Console.WriteLine(" Pressione [-- N --]->Não");
                            do
                            {
                                confirma = Console.ReadLine().ToUpper();
                                switch (confirma)
                                {
                                    case "S":
                                        flag = true;
                                        break;

                                    case "N":
                                        return;

                                    default:
                                        Console.WriteLine("Opção Inválida!");
                                        break;
                                }
                            } while (flag == false);

                            new AdotaServices().Delete(chip); //remove o registro de adocao
                            new AnimalServices().DesfazerAdocao(chip); //setta o animalzinho para o status "DISPONIVEL" novamente
                            Console.WriteLine("\n Desvinculo de Adoção Realizado com Sucesso!");
                            Pausa();
                            break;

                        case 3:
                            //MostrarAdotantesESeusPets
                            Console.Clear();
                            if (new AdotaServices().GetAll().Count == 0) Console.WriteLine("\n\nNão há nenhum Adodante Cadastrado!\n");

                            //se a lista não esta vazia, imprime todos
                            else new AdotaServices().GetAll().ForEach(x => Console.WriteLine(x));
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
        #region Functions_Adocao
        static void CadastrarAdocao()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\nPEDIDO DE ADOÇÃO\n\n");

                Console.Write("Informe o CPF da pessoa que irá fazer uma adoção (ou Pressione [-- S --] para sair): ");
                string cpf = Console.ReadLine();
                if (cpf.ToUpper() == "S") return;
                if (new PessoaServices().Exists(cpf) == false)
                {
                    Console.WriteLine("\n[-- Este CPF não esta Cadastrado ou não é valido! --]\n");
                    Pausa();
                    return;
                }


                Console.Write("\nInforme o CHIP de registro do Pet a ser Adotado (ou Pressione [-- S --] para sair): ");
                string chip = Console.ReadLine();
                if (chip.ToUpper() == "S") return;
                if (new AnimalServices().Exists(chip) == false)
                {
                    Console.WriteLine("\n[-- Este CHIP não esta Cadastrado ou não é valido! --]\n");
                    Pausa();
                    return;
                }


                if (new AnimalServices().ExistsDisponivel(chip) == false)
                {
                    Console.WriteLine("\n[-- CHIP não esta Disponível para Adoção. Este Pet Já foi Adotado! --]\n");
                    Pausa();
                    return;
                }

                new AdotaServices().Add(cpf, chip); //realiza o insert na adoção
                new AnimalServices().RealizarAdocao(chip); //setta o status do pet como "ADOTADO"

                Console.Clear();
                Console.WriteLine("\nAdoção Realizada com Sucesso!");
                Pausa();
            }
            catch (Exception e)
            {
                Console.WriteLine("Desculpe... Houve um Erro Inesperado durante o Processo de Adoção.\nTente Novamente.\n\n<<<" + e + ">>>");
            }
        }
        #endregion
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
