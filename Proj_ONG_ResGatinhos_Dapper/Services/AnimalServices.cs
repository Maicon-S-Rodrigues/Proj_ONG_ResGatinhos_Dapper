using Proj_ONG_ResGatinhos_Dapper.Model;
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
        public bool Add(Animal animal)
        {
            return _AnimalRepository.Add(animal);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool Exists(string chip)
        {
            return _AnimalRepository.Exists(chip);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public Animal Get(string chip)
        {
            return _AnimalRepository.Get(chip);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public List<Animal> GetAllAdotados()
        {
            return _AnimalRepository.GetAllAdotados();
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public List<Animal> GetAllDisponiveis()
        {
            return _AnimalRepository.GetAllDisponiveis();
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool UpdateFamilia(string chip, string familia)
        {
            return _AnimalRepository.UpdateFamilia(chip, familia);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool UpdateNome(string chip, string nome)
        {
            return _AnimalRepository.UpdateNome(chip, nome);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool UpdateRaca(string chip, string raca)
        {
            return _AnimalRepository.UpdateRaca(chip, raca);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool UpdateSexo(string chip, string sexo)
        {
            return _AnimalRepository.UpdateSexo(chip, sexo);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool RealizarAdocao(string chip)
        {
            return _AnimalRepository.RealizarAdocao(chip);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool ExistsDisponivel(string chip)
        {
            return _AnimalRepository.ExistsDisponivel(chip);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
        public bool DesfazerAdocao(string chip)
        {
            return _AnimalRepository.DesfazerAdocao(chip);
        }
        //_________________________________________________________________________________________//
        //_________________________________________________________________________________________//
    }
}
