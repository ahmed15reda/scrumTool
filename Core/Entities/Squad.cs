using System.Collections.Generic;

namespace Core.Entities
{
    public class Squad
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TFSUser> TFSUsers { get; set; } /*= new HashSet<TFSUser>();*/
    }
}
