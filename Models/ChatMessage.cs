using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProj.Models
{
    public class ChatMessage
    {
        public int ChatMessageId { get; set; }
        public string SenderName { get; set; }
        public string Message { get; set; }
        public DateTimeOffset SentAt { get; set; }
        public string Guid { get; set; }
        public User user { get; set; }
        public int? UserId { get; set; }
    }
}
