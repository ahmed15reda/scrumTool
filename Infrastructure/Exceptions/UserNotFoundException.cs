using System;

namespace Infrastructure.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message = "User Not Found!!") : base(message)
        {
        }
    }
}
