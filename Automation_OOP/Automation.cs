using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_OOP
{
    internal class Automation
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public List<Message> Messages { get; private set; }
        public List<User> Users { get; private set; }
        public User CurrentUser { get; private set; }
        public Automation(string title, string description)
        {
            Title = title;
            Description = description;
            Messages = new List<Message>();
            Users = new List<User>();
        }
        public override string ToString() => $"{Title} Automation System - Version[1]";
        public void SendMessage(Message message) => Messages.Add(message);
        public void AddUsers(User user) => Users.Add(user);
        public IEnumerable<Message> GetSendMessages(User user) => Messages.Where(m => m.Sender == user);
        public IEnumerable<Message> GetReceiveMessages(User user) => Messages.Where(m => m.Receiver == user || m.Type == user.UserType);
        public IEnumerable<User> GetUsers() => Users.Where(user => user != CurrentUser);
        public bool Login(string username, string password)
        {
            var query = Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
            if (query != null)
            {
                CurrentUser = query;
                return true;
            }
            else return false;
        }
    }
}