namespace ReleaseNotes.Service.Models.Email
{
    public class ReceiverViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long? SenderEmailConfigId { get; set; }
    }
}
