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
        Animal Get(string chip);
        bool Exists(string chip);
        bool UpdateFamilia(string chip, string familia);
        bool UpdateRaca(string chip, string raca);
        bool UpdateSexo(string chip, string sexo);
        bool UpdateNome(string chip, string nome);
        bool RealizarAdocao(string chip);
        bool DesfazerAdocao(string chip);
        bool ExistsDisponivel(string chip);

    }
}
