
namespace JobList.Common.Requests
{
    public class WorkAreaRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] PhotoData { get; set; }
        public string PhotoMimetype { get; set; }
    }
}
