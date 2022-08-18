using System;

namespace Infrastructure.Exceptions
{
    public class AbsentTypeNotFoundException: Exception
    {
        public AbsentTypeNotFoundException(string message = "AbsentType Not Found!!") : base(message)
        {
        }
    }
}
