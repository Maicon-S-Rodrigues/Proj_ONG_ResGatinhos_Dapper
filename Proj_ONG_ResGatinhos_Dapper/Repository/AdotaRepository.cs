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
    public class AdotaRepository : IAdotaRepository
    {
        private readonly string _conn;

        public AdotaRepository()
        {
            _conn = DataBaseConfiguration.Get();
        }

        public List<Adota> GetAll() //ok
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var adotados = db.Query<Adota>(Adota.SelectAll);

                return (List<Adota>)adotados;
            }
        }

        public List<Adota> GetAllAdotadosCpf(string cpf) //ok
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var adotados = db.Query<Adota>(Adota.SelectAllAdotadosCpf, new {Cpf = cpf});

                return (List<Adota>)adotados;
            }
        }

        public bool Add(Adota adota) //ok
        {
            bool result = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                db.Execute(Adota.Insert, adota);
                result = true;
            }
            return result;
        }

        public bool Delete(string chip) //ok
        {
            bool result = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                db.Execute(Adota.DeleteAdocao, new { Chip = chip});
                result = true;
            }
            return result;
        }


    }
}
