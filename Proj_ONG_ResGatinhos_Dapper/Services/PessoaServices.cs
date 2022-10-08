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

        public PessoaServices()
        {
            _PessoaRepository = new PessoaRepository();
        }

        public bool Add (Pessoa pessoa)
        {
            return _PessoaRepository.Add(pessoa);
        }

        public List<Pessoa> GetAll()
        {
            return _PessoaRepository.GetAll();
        }
    }
}
