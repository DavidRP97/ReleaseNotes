using System.Text.Json.Serialization;

namespace ReleaseNotes.Service.Models.Email
{
    public class SendSmtpEmailSender
    {
        [JsonPropertyName("name")]
        public string SenderName { get; set; }
        [JsonPropertyName("email")]
        public string SenderEmail { get; set; }
    }
}
