using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG_ResGatinhos_Dapper.Repository
{
    internal interface IPetRepository
    {
        bool Add(Animal animal);
        List<Animal> GetAll();
        public bool Exists(string cpf);
        Animal Get(string cpf);
        bool UpdateNome(string cpf, string nome);
    }
}
