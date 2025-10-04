using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_OOP
{
    internal class Message
    {
        public DateTime Date { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public bool Read { get; private set; }
        public User Sender { get; private set; }
        public User Receiver { get; private set; }
        public User.type Type { get; private set; }
        public Message(DateTime date, string subject, string body, User sender, User receiver)
        {
            Date = date;
            Subject = subject;
            Body = body;
            Sender = sender;
            Receiver = receiver;
            Read = false;
        }
        public Message(DateTime date, string subject, string body, User sender, User.type type)
        {
            Date = date;
            Subject = subject;
            Body = body;
            Sender = sender;
            Type = type;
        }
        public void ReadMessage()
        {
            Read = true;
        }
    }
}