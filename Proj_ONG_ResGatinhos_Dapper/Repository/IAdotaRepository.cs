using Proj_ONG_ResGatinhos_Dapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG_ResGatinhos_Dapper.Repository
{
    internal interface IAdotaRepository
    {
        public List<Adota> GetAll();
        public List<Adota> GetAllAdotadosCpf(string cpf);
        public bool Add(Adota adota);
        public bool Delete(string chip);
    }
}
