namespace Core.Dto
{
    public class VacationSummaryDto
    {
        public string VacationType { get; set; }
        public int TotalDays { get; set; }
        public int TakenDays { get; set; }
        public int RemainingDays { get; set; }
        public EmployeeAbsenceDto Vacations { get; set; }
        public int UserRoleId { get; set; }
    }
}
