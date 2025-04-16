using Dapper;
using System.Data;
using System.Data.SqlClient;
using AzureAPI.Entities;

namespace AzureAPI.DB
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public int InsertarUsuario(User usuario)
        {
            using var db = Connection;
            var parametros = new DynamicParameters();
            parametros.Add("@Cedula", usuario.Cedula);
            parametros.Add("@Nombre", usuario.Nombre);
            parametros.Add("@Telefono", usuario.Telefono);
            parametros.Add("@Observaciones", usuario.Observaciones);

            return db.ExecuteScalar<int>("SP_InsertarUsuario", parametros, commandType: CommandType.StoredProcedure);
        }

        public List<User> ObtenerUsuarios()
        {
            using var db = Connection;
            return db.Query<User>("SP_ObtenerUsuarios", commandType: CommandType.StoredProcedure).ToList();
        }

        public User ObtenerUsuarioPorId(int id)
        {
            using var db = Connection;
            return db.QueryFirstOrDefault<User>(
                "SP_ObtenerUsuarioPorId",
                new { IdUsuario = id },
                commandType: CommandType.StoredProcedure);
        }

        public bool ActualizarUsuario(User usuario)
        {
            using var db = Connection;
            var parametros = new DynamicParameters();
            parametros.Add("@IdUsuario", usuario.IdUsuario);
            parametros.Add("@Cedula", usuario.Cedula);
            parametros.Add("@Nombre", usuario.Nombre);
            parametros.Add("@Telefono", usuario.Telefono);
            parametros.Add("@Observaciones", usuario.Observaciones);

            int filas = db.Execute("SP_ActualizarUsuario", parametros, commandType: CommandType.StoredProcedure);
            return filas > 0;
        }

        public bool EliminarUsuario(int id)
        {
            using var db = Connection;
            int filas = db.Execute(
                "SP_EliminarUsuario",
                new { IdUsuario = id },
                commandType: CommandType.StoredProcedure);
            return filas > 0;
        }
    }
}