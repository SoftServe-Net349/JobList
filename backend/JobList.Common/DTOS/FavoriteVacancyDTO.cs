using JobList.Common.Interfaces.Entities;

namespace JobList.Common.DTOS
{
    public class FavoriteVacancyDTO : IEntity<int>
    {
        public int Id { get; set; }
        public int EmployeerId { get; set; }
        public int VacancyId { get; set; }
    }
}
