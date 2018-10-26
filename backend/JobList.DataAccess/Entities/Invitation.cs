
namespace JobList.DataAccess.Entities
{
    public class Invitation: Entity<int>
    {
        public override int Id { get; set; }
        public int EmployeeId { get; set; }
        public int VacancyId { get; set; }

        public Employee Employee { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}
