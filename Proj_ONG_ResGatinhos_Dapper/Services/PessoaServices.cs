using Proj_ONG_ResGatinhos_Dapper.Model;
using Proj_ONG_ResGatinhos_Dapper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG_ResGatinhos_Dapper.Services
{
    public class PessoaServices
    {
        private IPessoaRepository _PessoaRepository;

        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public PessoaServices()
        {
            _PessoaRepository = new PessoaRepository();
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool Add (Pessoa pessoa)
        {
            return _PessoaRepository.Add(pessoa);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public List<Pessoa> GetAll()
        {
            return _PessoaRepository.GetAll();
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool Exists(string cpf)
        {
            return _PessoaRepository.Exists(cpf);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public Pessoa Get(string cpf)
        {
            return _PessoaRepository.Get(cpf);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool UpdateNome(string cpf, string nome)
        {
            return _PessoaRepository.UpdateNome(cpf, nome);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool UpdateSexo(string cpf, string sexo)
        {
            return _PessoaRepository.UpdateSexo(cpf, sexo);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool UpdateTelefone(string cpf, string telefone)
        {
            return _PessoaRepository.UpdateTelefone(cpf, telefone);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool UpdateDataNascimento(string cpf, DateTime dataNascimento)
        {
            return _PessoaRepository.UpdateDataNascimento(cpf, dataNascimento);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool UpdateEndereco(string cpf, string cidade, string estado, string bairro, string rua, int numero, string complemento)
        {
            return _PessoaRepository.UpdateEndereco(cpf, cidade, estado, bairro, rua, numero, complemento);
        }
    }
}
