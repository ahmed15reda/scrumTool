using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserRole
    {
        public int Id { get; set; }
        public UserRoles Name { get; set; }
        public virtual ICollection<TFSUser> TFSUsers { get; set; } = new HashSet<TFSUser>();
    }
}
