using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Response
{
    public class SuccessMessageResponse : GeneralResponse
    {
        public SuccessMessageResponse(string message, bool status = true) : base(message, status)
        {
        }
    }
}
