using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_OOP
{
    internal class Automation
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Message> Messages { get; private set; }
        public List<User> Users { get; private set; }
        public User CurrentUser { get; set; }
        public Automation(string title, string description)
        {
            Title = title;
            Description = description;
            Messages = new List<Message>();
            Users = new List<User>();
        }
        public override string ToString()
        {
            return $"{Title} Automation System - Version[1]";
        }
        public void SendMessage(Message message)
        {
            Messages.Add(message);
        }
        public void AddUsers(User user)
        {
            Users.Add(user);
        }
        public IEnumerable<Message> GetSendMessages(User user)
        {
            return from message in Messages
                   where message.Sender == user
                   select message;
        }
        public IEnumerable<Message> GetReceiveMessages(User user)
        {
            return from Message in Messages
                   where Message.Receiver == user || Message.Type == user.UserType
                   select Message;
        }
        public IEnumerable<User> GetUsers()
        {
            return Users.Where(user => user != CurrentUser);
        }
        public bool Login(string username, string password)
        {
            var query = from user in Users where user.Username == username && user.Password == password select user;
            if (query.Count() > 0)
            {
                CurrentUser = query.ToList()[0];
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}