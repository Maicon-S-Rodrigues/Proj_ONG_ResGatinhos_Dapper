using Proj_ONG_ResGatinhos_Dapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG_ResGatinhos_Dapper.Repository
{
    internal interface IPessoaRepository
    {
        bool Add(Pessoa pessoa);   
        List<Pessoa> GetAll();
        Pessoa Get(string cpf);
        bool UpdateNome(string cpf, string nome);
        bool UpdateTelefone(string cpf, string telefone);
        bool UpdateDataNascimento(string cpf, DateTime dataNascimento);
        bool UpdateSexo(string cpf, string sexo);
        bool UpdateEndereco(string cpf, string cidade, string estado, string bairro, string rua, int numero, string complemento);
    }
}
