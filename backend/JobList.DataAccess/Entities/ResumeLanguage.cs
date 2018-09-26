
namespace JobList.DataAccess.Entities
{
    public class ResumeLanguage : Entity<int>
    {
        public override int Id { get; set; }
        public int ResumeId { get; set; }
        public int LanguageId { get; set; }

        public Language Language { get; set; }
        public Resume Resume { get; set; }
    }
}
