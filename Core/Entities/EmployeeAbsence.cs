using Core.Enum;
using System;

namespace Core.Entities
{
    public class EmployeeAbsence
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AnnualVacationsCount { get; set; }
        public int CasualVacationsCount { get; set; }
        public int WorkFromHomeCount { get; set; }
        public int SickLeaveCount { get; set; }
        public int MaternityLeaveCount { get; set; }
        public int WorkYearId { get; set; }
        public WorkYear WorkYear { get; set; }
        public int AbsenceTypeId { get; set; }
        public AbsenceTypes AbsenceType { get; set; }
        public AbsenceStatus AbsenceStatus { get; set; }
        public int TFSUserId { get; set; }
        public TFSUser TFSUser { get; set; }
    }
}
