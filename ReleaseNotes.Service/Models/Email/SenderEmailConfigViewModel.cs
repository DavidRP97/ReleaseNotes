namespace ReleaseNotes.Service.Models.Email
{
    public class SenderEmailConfigViewModel
    {
        public long SenderConfigId { get; set; }
        public ICollection<ReceiverViewModel>? Receivers { get; set; }
        public virtual SenderViewModel Sender { get; set; }
    }
}
