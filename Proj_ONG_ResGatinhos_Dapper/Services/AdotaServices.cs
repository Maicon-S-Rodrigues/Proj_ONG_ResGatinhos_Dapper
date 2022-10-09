using Proj_ONG_ResGatinhos_Dapper.Model;
using Proj_ONG_ResGatinhos_Dapper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG_ResGatinhos_Dapper.Services
{
    public class AdotaServices
    {
        private IAdotaRepository _AdotaRepository;

        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public AdotaServices()
        {
            _AdotaRepository = new AdotaRepository();
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public List<Adota> GetAll()
        {
            return _AdotaRepository.GetAll();
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public List<Adota> GetAllAdotadosCpf(string cpf)
        {
            return _AdotaRepository.GetAllAdotadosCpf(cpf);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool Add(Adota adota)
        {
            return _AdotaRepository.Add(adota);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool Delete(string chip)
        {
            return _AdotaRepository.Delete(chip);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
    }
}
