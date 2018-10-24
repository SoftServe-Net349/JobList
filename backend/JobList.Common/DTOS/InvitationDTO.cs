using JobList.Common.Interfaces.Entities;

namespace JobList.Common.DTOS
{
    public class InvitationDTO : IEntity<int>
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public VacancyDTO Vacancy { get; set; }
    }
}
