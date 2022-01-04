using System.Text.Json.Serialization;

namespace ReleaseNotes.Service.Models.Email
{
    public class SendSmtpEmailTo
    {
        [JsonPropertyName("name")]
        public string ToName { get; set; }
        [JsonPropertyName("email")]
        public string ToEmail { get; set; }
    }
}
