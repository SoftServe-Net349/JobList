using JobList.Common.Interfaces.Entities;

namespace JobList.Common.DTOS
{
    public class CompanyDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BossName { get; set; }
        public string FullDescription { get; set; }
        public string ShortDescription { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string LogoData { get; set; }
        public string LogoMimetype { get; set; }
        public string Site { get; set; }
        public string Email { get; set; }

        public RoleDTO Role { get; set; }
    }
}
