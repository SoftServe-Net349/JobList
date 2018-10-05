using JobList.Common.Interfaces.Entities;

namespace JobList.Common.DTOS
{
    public class LanguageDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
