using Core.Enum;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public DepartmentTypes Name { get; set; }
        public virtual ICollection<TFSUser> TFSUsers { get; set; } = new HashSet<TFSUser>();
    }
}
