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
        bool Add(Pessoa pessoa);//ok
        List<Pessoa> GetAll();//ok
        public bool Exists(string cpf);//ok
        Pessoa Get(string cpf);//ok
        bool UpdateNome(string cpf, string nome);//ok
        bool UpdateTelefone(string cpf, string telefone);//ok
        bool UpdateDataNascimento(string cpf, DateTime dataNascimento);//ok
        bool UpdateSexo(string cpf, string sexo);//ok
        bool UpdateEndereco(string cpf, string cidade, string estado, string bairro, string rua, int numero, string complemento);//ok
    }
}
