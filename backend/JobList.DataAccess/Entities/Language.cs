using System.Collections.Generic;

namespace JobList.DataAccess.Entities
{
    public class Language : Entity<int>
    {
        public Language()
        {
            ResumeLanguages = new HashSet<ResumeLanguage>();
        }

        public override int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ResumeLanguage> ResumeLanguages { get; set; }
    }
}
