using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions
{
    public class ConfigurationNotFoundException: Exception
    {
        public ConfigurationNotFoundException(string message = "Configuration Not Found!!") : base(message)
        {
        }
    }
}
