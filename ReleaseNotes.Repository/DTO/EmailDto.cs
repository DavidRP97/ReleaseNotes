namespace ReleaseNotes.Repository.DTO
{
    public class EmailDto
    {
        public long SenderConfigId { get; set; }      
        public ICollection<ReceiverDto>? Receivers { get; set; }
        public virtual SenderDto Sender { get; set; }
    }
}
