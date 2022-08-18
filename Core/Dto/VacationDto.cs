using Core.Entities;
using Core.Enum;
using System;
using System.Collections.Generic;

namespace Core.Dto
{
    public class VacationDto
    {
        public int Id { get; set; }
        public List<TFSUser> Users { get; set; }
        public List<AbsenceTypes> AbsenceTypes { get; set; }
        public AbsenceStatus AbsenceStatus { get; set; } = AbsenceStatus.Pending;
        public int TFSUserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WorkYearId { get; set; }
        public int AbsenceTypeId { get; set; }
        public int UserRoleId { get; set; }
    }
}
