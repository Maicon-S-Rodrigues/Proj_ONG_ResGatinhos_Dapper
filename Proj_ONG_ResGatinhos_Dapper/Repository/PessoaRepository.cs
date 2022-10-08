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
    public class PessoaRepository : IPessoaRepository
    {
        private readonly string _conn;

        public PessoaRepository()
        {
            _conn = DataBaseConfiguration.Get();
        }


        public bool Add(Pessoa pessoa) // ok
        {
            bool result = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                db.Execute(Pessoa.Insert, pessoa);
                result = true;
            }
            return result;
        }
        public bool Exists(string cpf) //verifica se o cpf ja existe cadastrado
        {
            bool existe = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var result = db.ExecuteScalar(Pessoa.Exists, new { Cpf = cpf });
                if (result != null)
                {
                    existe = true;
                    return existe;
                }
            }
            return existe;
        }


        public Pessoa Get(string cpf) // ok 
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();

                var pessoa = db.QueryFirst<Pessoa>(Pessoa.SelectOne, new { Cpf = cpf });

                return (Pessoa)pessoa;
            }
        }

        public List<Pessoa> GetAll() // ok 
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var pessoa = db.Query<Pessoa>(Pessoa.SelectAll);

                return (List<Pessoa>)pessoa;
            }
        }

        public bool UpdateDataNascimento(string cpf, DateTime dataNascimento) // ok
        {
            bool updated = false;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var result = db.Execute(Pessoa.UpdateData_Nascimento, new { Data_Nascimento = dataNascimento, Cpf = cpf });
                if (result != 0)
                {
                    updated = true;
                    return updated;
                }
            }
            return updated;
        }

        public bool UpdateEndereco(string cpf, string cidade, string estado, string bairro, string rua, int numero, string complemento) // ok
        {
            bool updated = false;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var result = db.Execute(Pessoa.UpdateEndereco, new
                {
                    Cpf = cpf,
                    Cidade = cidade,
                    Estado = estado,
                    Bairro = bairro,
                    Rua = rua,
                    Numero = numero,
                    Complemento = complemento
                });
                if (result != 0)
                {
                    updated = true;
                    return updated;
                }
            }
            return updated;
        }

        public bool UpdateNome(string cpf, string nome) // ok 
        {
            bool updated = false;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var result = db.Execute(Pessoa.UpdateNome, new { Nome = nome, Cpf = cpf });
                if (result != 0)
                {
                    updated = true;
                    return updated;
                }
            }
            return updated;
        }

        public bool UpdateSexo(string cpf, string sexo) // ok 
        {
            bool updated = false;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var result = db.Execute(Pessoa.UpdateSexo, new { Sexo = sexo, Cpf = cpf });
                if (result != 0)
                {
                    updated = true;
                    return updated;
                }
            }
            return updated;
        }

        public bool UpdateTelefone(string cpf, string telefone) // ok
        {
            bool updated = false;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var result = db.Execute(Pessoa.UpdateTelefone, new { Telefone = telefone, Cpf = cpf });
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
