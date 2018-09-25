using JobList.Common.Interfaces.Entities;

namespace JobList.Common.DTOS
{
    public class ResumeLanguageDTO : IEntity<int>
    {
        public int Id { get; set; }
        public int ResumeId { get; set; }
        public int LanguageId { get; set; }
    }
}
