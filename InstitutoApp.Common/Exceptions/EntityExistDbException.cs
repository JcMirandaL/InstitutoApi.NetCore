

namespace InstitutoApp.Common.Exceptions
{
    public class EntityExistDbException : Exception
    {
        public EntityExistDbException(string message) : base(message)
        {
        }
    }
}
