using Proj_ONG_ResGatinhos_Dapper.Config;
using Proj_ONG_ResGatinhos_Dapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG_ResGatinhos_Dapper.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly string _conn;

        public AnimalRepository()
        {
            _conn = DataBaseConfiguration.Get();
        }

        public bool Add(Animal animal)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string chip)
        {
            throw new NotImplementedException();
        }

        public Pessoa Get(string chip)
        {
            throw new NotImplementedException();
        }

        public List<Animal> GetAllAdotados()
        {
            throw new NotImplementedException();
        }

        public List<Animal> GetAllDisponiveis()
        {
            throw new NotImplementedException();
        }

        public bool UpdateFamilia(string chip, string familia)
        {
            throw new NotImplementedException();
        }

        public bool UpdateNome(string chip, string nome)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRaca(string chip, string raca)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSexo(string chip, string sexo)
        {
            throw new NotImplementedException();
        }
    }
}
