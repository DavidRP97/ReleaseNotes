using Microsoft.AspNetCore.Http;
using ReleaseNotes.Service.Utils;
using System.ComponentModel.DataAnnotations;

namespace ReleaseNotes.Service.Models.Call
{
    public class CallViewModel
    {
        public long CallId { get; set; }
        public long? FeedbackId { get; set; }
        public bool IsUrgent { get; set; }
        public Priority PriorityDegree { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public FeedbackFrom Software { get; set; }
        public Filters Filters { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Imagem { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Detail { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Subject { get; set; }
        public string Date { get; set; }

        public DateTime DateToDatetime
        {
            get { return Convert.ToDateTime(Date); }
        }
    }
}
