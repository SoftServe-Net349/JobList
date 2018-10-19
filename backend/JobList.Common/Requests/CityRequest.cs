
namespace JobList.Common.Requests
{
    public class CityRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] PhotoData { get; set; }
        public string PhotoMimeType { get; set; }
    }
}
