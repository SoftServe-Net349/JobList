using JobList.Common.Interfaces.Entities;

namespace JobList.Common.DTOS
{
    public class CityDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] PhotoData { get; set; }
        public string PhotoMimetype { get; set; }
    }
}
