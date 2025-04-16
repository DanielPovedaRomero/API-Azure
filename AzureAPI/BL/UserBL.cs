using AzureAPI.DB;
using AzureAPI.Entities;

namespace AzureAPI.BL
{
    public class UserBL
    {
        private readonly UserRepository _db;

        public UserBL(string connectionString)
        {
            _db = new UserRepository(connectionString);
        }

        public Response<List<User>> ObtenerUsuarios()
        {
            var lista = _db.ObtenerUsuarios();
            if (lista == null || !lista.Any())
                return Response<List<User>>.Error("No se encontraron usuarios.");

            return Response<List<User>>.Ok(lista);
        }

        public Response<User> ObtenerUsuarioPorId(int id)
        {
            var usuario = _db.ObtenerUsuarioPorId(id);
            if (usuario == null)
                return Response<User>.Error("Usuario no encontrado.");

            return Response<User>.Ok(usuario);
        }

        public Response<User> InsertarUsuario(User usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Cedula) || string.IsNullOrWhiteSpace(usuario.Nombre))
                return Response<User>.Error("La cédula y el nombre son obligatorios.");

            var id = _db.InsertarUsuario(usuario);
            usuario.IdUsuario = id;

            return Response<User>.Ok(usuario, "Usuario creado correctamente.");
        }

        public Response<string> ActualizarUsuario(User usuario)
        {
            var existe = _db.ObtenerUsuarioPorId(usuario.IdUsuario);
            if (existe == null)
                return Response<string>.Error("El usuario no existe.");

            var ok = _db.ActualizarUsuario(usuario);
            return ok
                ? Response<string>.Ok(null, "Usuario actualizado correctamente.")
                : Response<string>.Error("No se pudo actualizar el usuario.");
        }

        public Response<string> EliminarUsuario(int id)
        {
            var existe = _db.ObtenerUsuarioPorId(id);
            if (existe == null)
                return Response<string>.Error("El usuario no existe.");

            var ok = _db.EliminarUsuario(id);
            return ok
                ? Response<string>.Ok(null, "Usuario eliminado correctamente.")
                : Response<string>.Error("No se pudo eliminar el usuario.");
        }
    }
}