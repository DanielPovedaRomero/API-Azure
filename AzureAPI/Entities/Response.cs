using NPOI.SS.Formula.Functions;

namespace AzureAPI.Entities
{
    public class Response<T>
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public T Datos { get; set; }

        public static Response<T> Ok(T data, string mensaje = "Operación exitosa")
        {
            return new Response<T> { Exito = true, Mensaje = mensaje, Datos = data };
        }

        public static Response<T> Error(string mensaje)
        {
            return new Response<T> { Exito = false, Mensaje = mensaje, Datos = default };
        }
    }
}
