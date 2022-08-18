using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class UserSessionDto
    {
        public string UserToken { get; set; }
        public UserRoles UserRole { get; set; }
        public TFSUserDto User { get; set; }
    }
}
