using Core.Enum;

namespace Core.Entities
{
    public class AbsenceTypes
    {
        public int Id { get; set; }
        public AbsenceType Name { get; set; }
        public int DaysCount { get; set; }
        public bool IsActive { get; set; }
    }
}
