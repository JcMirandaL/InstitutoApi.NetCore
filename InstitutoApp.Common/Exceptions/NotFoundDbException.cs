

namespace InstitutoApp.Common.Exceptions
{
    public class NotFoundDbException : Exception
    {
        //SI LLAMO ESTE YA VA CON ESTE MSJ
        //USAR EL DE ABAJO PARA PERSONALIZAR EL MSJ
        public NotFoundDbException() : base("La entidad NO existe en la base de datos") { }

        //constructor que recibe un mensaje personalizado, viene de la clase padre Exception
        //y se le pasa el msj x parametro 
        public NotFoundDbException(string message) : base(message) { }
    }
}
