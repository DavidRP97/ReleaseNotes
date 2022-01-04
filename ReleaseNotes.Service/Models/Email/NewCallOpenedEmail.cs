using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReleaseNotes.Service.Models.Email
{
    public class NewCallOpenedEmail
    {

        [JsonPropertyName("to")]
        public List<SendSmtpEmailTo> SendSmtpEmailTo { get; set; }
        [JsonPropertyName("sender")]
        public virtual SendSmtpEmailSender EmailSender { get; set; }
        [JsonPropertyName("subject")]
        public string Subject { get; set; }
        [JsonPropertyName("htmlContent")]
        public string Content { get; set; }
    }
}
