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
    }
}
