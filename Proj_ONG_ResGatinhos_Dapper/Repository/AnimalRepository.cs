using Dapper;
using Proj_ONG_ResGatinhos_Dapper.Config;
using Proj_ONG_ResGatinhos_Dapper.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public bool Add(Animal animal)//ok
        {
            bool result = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                db.Execute(Animal.Insert, animal);
                result = true;
            }
            return result;
        }

        public bool Exists(string chip)//ok
        {
            bool existe = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var result = db.ExecuteScalar(Animal.Exists, new { Chip = chip });
                if (result != null)
                {
                    existe = true;
                    return existe;
                }
            }
            return existe;
        }

        public Animal Get(string chip)//ok
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();

                var animal = db.QueryFirst<Animal>(Animal.SelectOne, new { Chip = chip });

                return (Animal)animal;
            }
        }

        public List<Animal> GetAllAdotados()//ok
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var animal = db.Query<Animal>(Animal.SelectAdotados);

                return (List<Animal>)animal;
            }
        }

        public List<Animal> GetAllDisponiveis()//ok
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var animal = db.Query<Animal>(Animal.SelectDisponiveis);

                return (List<Animal>)animal;
            }
        }

        public bool UpdateFamilia(string chip, string familia)//ok
        {
            bool updated = false;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var result = db.Execute(Animal.UpdateFamilia, new { Familia = familia, Chip = chip });
                if (result != 0)
                {
                    updated = true;
                    return updated;
                }
            }
            return updated;
        }

        public bool UpdateNome(string chip, string nome)//ok
        {
            bool updated = false;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var result = db.Execute(Animal.UpdateNome, new { Nome = nome, Chip = chip });
                if (result != 0)
                {
                    updated = true;
                    return updated;
                }
            }
            return updated;
        }

        public bool UpdateRaca(string chip, string raca)//ok
        {
            bool updated = false;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var result = db.Execute(Animal.UpdateRaca, new { Raca = raca, Chip = chip });
                if (result != 0)
                {
                    updated = true;
                    return updated;
                }
            }
            return updated;
        }

        public bool UpdateSexo(string chip, string sexo)//ok
        {
            bool updated = false;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var result = db.Execute(Animal.UpdateSexo, new { Sexo = sexo, Chip = chip });
                if (result != 0)
                {
                    updated = true;
                    return updated;
                }
            }
            return updated;
        }
    }
}
