using System;

namespace Core.Dto
{
    public class EmployeeAbsenceDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string AbsentTypeName { get; set; }
        public string AbsentStatusName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DaysCount { get; set; }
        public int SquadId { get; set; }
    }
}
