

namespace InstitutoApp.Common.Response
{
    public class Response <T>
    {
        public string Message { get; set; } = string.Empty;

        //el ? es para indicar que el tipo de dato puede ser nulo, xq en algunos casos no se va a devolver data,
        //como por ejemplo en el metodo eliminar, donde solo se devuelve un booleano
        public T? Data { get; set; }


        public bool Success { get; set; }
    }
}
