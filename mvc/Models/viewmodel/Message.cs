using System;
namespace mvc.Models.viewmodel
{
    public class Message
    {
        public string Header { get; set; }
        public string MessageText { get; set; }

        public Message() : this("", "") { }
        public Message(string header, string messageText)
        {
            this.Header = header;
            this.MessageText = messageText;
        }
    }
}
