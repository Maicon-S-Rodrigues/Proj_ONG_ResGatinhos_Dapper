using Proj_ONG_ResGatinhos_Dapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG_ResGatinhos_Dapper.Repository
{
    internal interface IAnimalRepository
    {
        bool Add(Animal animal);
        List<Animal> GetAllAdotados();
        List<Animal> GetAllDisponiveis();
        public bool Exists(string chip);
        Pessoa Get(string chip);
        bool UpdateFamilia(string chip, string familia);
        bool UpdateRaca(string chip, string raca);
        bool UpdateSexo(string chip, string sexo);
        bool UpdateNome(string chip, string nome);
    }
}
