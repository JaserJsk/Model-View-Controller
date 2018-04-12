using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcChat.Models
{
    public class MessageModel
    {
        public string Message { get; set; }
        public string User { get; set; }
        public DateTime Sent { get; set; }
    }
}