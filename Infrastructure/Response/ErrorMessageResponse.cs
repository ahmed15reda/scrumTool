using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Response
{
    public class ErrorMessageResponse : GeneralResponse
    {
        public ErrorMessageResponse(string message, bool status = false) : base(message, status)
        {
        }
    }
}
