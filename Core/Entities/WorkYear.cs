using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class WorkYear
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; } = new DateTime(DateTime.Now.Year, 1, 1);
        public DateTime EndDate { get; set; } = new DateTime(DateTime.Now.Year, 12, 31);
        public bool IsCurrentYear { get; set; }
    }
}
