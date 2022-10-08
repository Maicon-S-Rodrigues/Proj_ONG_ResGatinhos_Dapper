using Proj_ONG_ResGatinhos_Dapper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG_ResGatinhos_Dapper.Services
{
    public class AnimalServices
    {
        private IAnimalRepository _AnimalRepository;

        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public AnimalServices()
        {
            _AnimalRepository = new AnimalRepository();
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
    }
}
