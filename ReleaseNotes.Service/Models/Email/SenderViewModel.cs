namespace ReleaseNotes.Service.Models.Email
{
    public class SenderViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long? SenderEmailConfigId { get; set; }
    }
}
