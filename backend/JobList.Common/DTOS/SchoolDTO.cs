using JobList.Common.Interfaces.Entities;

namespace JobList.Common.DTOS
{
    public class SchoolDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
