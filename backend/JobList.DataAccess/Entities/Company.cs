using System.Collections.Generic;

namespace JobList.DataAccess.Entities
{
    public class Company : Entity<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public string BossName { get; set; }
        public string FullDescription { get; set; }
        public string ShortDescription { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public byte[] LogoData { get; set; }
        public string LogoMimetype { get; set; }
        public string Site { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string RefreshToken { get; set; }

        public Role Role { get; set; }
        public IList<Recruiter> Recruiters { get; set; }
    }
}
