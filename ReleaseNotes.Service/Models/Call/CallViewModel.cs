﻿using ReleaseNotes.Service.Utils;

namespace ReleaseNotes.Service.Models.Call
{
    public class CallViewModel
    {
        public long CallId { get; set; }
        public long? FeedbackId { get; set; }
        public bool IsUrgent { get; set; }
        public Priority PriorityDegree { get; set; }
        public Status Status { get; set; }
        public FeedbackFrom Software { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Detail { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
    }
}