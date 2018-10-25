using JobList.Common.Interfaces.Entities;

namespace JobList.Common.DTOS
{
    public class WorkAreaDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
