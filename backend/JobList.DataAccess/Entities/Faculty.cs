
namespace JobList.DataAccess.Entities
{
    public class Faculty : Entity<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public int SchoolId { get; set; }

        public School School { get; set; }
    }
}
