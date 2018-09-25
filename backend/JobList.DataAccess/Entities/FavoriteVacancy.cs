
namespace JobList.DataAccess.Entities
{
    public class FavoriteVacancy : Entity<int>
    {
        public override int Id { get; set; }
        public int VacancyId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}
