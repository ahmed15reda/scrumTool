using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Response
{
    public class ValidationResponse : GeneralResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ValidationResponse(IEnumerable<string> errors, string message = "Some unexpected data", bool status = false) : base(message, status)
        {
            Errors = errors;
        }
    }
}
