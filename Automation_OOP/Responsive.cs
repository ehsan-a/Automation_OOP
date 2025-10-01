using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_OOP
{
    internal class Responsive
    {
        public static void Login(Automation automation)
        {
            while (true)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                if (automation.Login(username, password))
                {
                    Console.WriteLine(automation);
                    Console.WriteLine($"User [{automation.CurrentUser.FirstName} {automation.CurrentUser.LastName}] - SendBox [{automation.GetSendMessages(automation.CurrentUser).ToList().Count}] - ReceiveBox [{automation.GetReceiveMessages(automation.CurrentUser).ToList().Count}]");
                    break;
                }
                else
                {
                    Console.WriteLine("Error Login!");
                }
            }
        }
        public static void GetSentMessages(Automation automation)
        {
            int counter = 1;
            foreach (var item in automation.GetSendMessages(automation.CurrentUser))
            {
                Console.WriteLine($"[{counter}] - Receiver: [{(item.Receiver != null ? item.Receiver.FirstName + " " + item.Receiver.LastName : item.Type + " Group")}] - Date/Time: [{item.Date}] - Subjet: [{item.Subject}]");
                counter++;
            }
            while (true)
            {
                Console.Write("Enter Number of Message to Show (Cancel [c]): ");
                string input = Console.ReadLine().ToLower();
                if (input == "c") break;
                if (!int.TryParse(input, out int index))
                {
                    Console.WriteLine("Out of Range");
                    continue;
                }
                if (index <= 0 || index > automation.GetSendMessages(automation.CurrentUser).ToList().Count)
                {
                    Console.WriteLine("Out of Range");
                    continue;
                }
                var item = automation.GetSendMessages(automation.CurrentUser).ToList()[index - 1];
                Console.WriteLine($"Receiver: [{item.Receiver.FirstName} {item.Receiver.LastName}] - Date/Time: [{item.Date}] - Subjet: [{item.Subject}]");
                Console.WriteLine($"Message: [{item.Body}]");
            }
        }
        public static void GetReceiveMessages(Automation automation)
        {
            int counter = 1;
            foreach (var item in automation.GetReceiveMessages(automation.CurrentUser))
            {
                Console.WriteLine($"[{counter}] - Sender: [{item.Sender.FirstName} {item.Sender.LastName}] - Date/Time: [{item.Date}] - Subjet: [{item.Subject}]");
                counter++;
            }
            while (true)
            {
                Console.Write("Enter Number of Message to Show (Cancel [c]): ");
                string input = Console.ReadLine().ToLower();
                if (input == "c") break;
                if (!int.TryParse(input, out int index))
                {
                    Console.WriteLine("Out of Range");
                    continue;
                }
                if (index <= 0 || index > automation.GetReceiveMessages(automation.CurrentUser).ToList().Count)
                {
                    Console.WriteLine("Out of Range");
                    continue;
                }
                var item = automation.GetReceiveMessages(automation.CurrentUser).ToList()[int.Parse(input) - 1];
                Console.WriteLine($"Sender: [{item.Sender.FirstName} {item.Sender.LastName}] - Receiver: [{(item.Receiver != null ? item.Receiver.FirstName + " " + item.Receiver.LastName : item.Type + " Group")}] - Date/Time: [{item.Date}] - Subjet: [{item.Subject}]");
                Console.WriteLine($"Message: [{item.Body}]");
            }
        }
        public static void SendMessageUser(Automation automation)
        {
            int counter = 1;
            foreach (var item in automation.GetUsers())
            {
                Console.WriteLine($"[{counter}] First Name: [{item.FirstName}] - Last Name: [{item.LastName}] - Username: [{item.Username}] - Type: [{item.UserType}]");
                counter++;
            }
            while (true)
            {
                Console.Write("Enter Number of Users For Send Message (Cancel [c]): ");
                string input = Console.ReadLine();
                if (input == "c") break;
                if (!int.TryParse(input, out int index))
                {
                    Console.WriteLine("Out of Range");
                    continue;
                }
                if (index <= 0 || index > automation.GetUsers().ToList().Count)
                {
                    Console.WriteLine("Out of Range");
                    continue;
                }
                User receiver = automation.GetUsers().ToList()[index - 1];
                Console.Write("Enter Subjet of Message: ");
                string subject = Console.ReadLine();
                Console.Write("Write Your Message: ");
                string message = Console.ReadLine();
                Console.Write("Are You Sure? (Yes [y]) (No [n]): ");
                string confirm = Console.ReadLine().ToLower();
                if (confirm != "n" && confirm != "y")
                {
                    Console.WriteLine("Out of Range");
                    continue;
                }
                else if (confirm == "y")
                {
                    automation.SendMessage(new Message(DateTime.Now, subject, message, automation.CurrentUser, receiver));
                    Console.WriteLine("Successful!");
                }
                else
                {
                    continue;
                }
            }
        }
        public static void SendMessageGroup(Automation automation)
        {
            int counter = 1;
            Console.WriteLine($"[0] {User.type.Junior} - [1] {User.type.MidLevel} - [2] {User.type.Senior}");
            while (true)
            {
                Console.Write("Enter Number of Group For Send Message (Cancel [c]): ");
                string input = Console.ReadLine();
                if (input == "c") break;
                User.type type = User.type.Junior;
                bool notValid = false;
                switch (input)
                {
                    case "0":
                        type = User.type.Junior;
                        break;
                    case "1":
                        type = User.type.MidLevel;
                        break;
                    case "2":
                        type = User.type.Senior;
                        break;
                    default:
                        notValid = true;
                        break;
                }
                if (notValid) continue;
                Console.Write("Enter Subjet of Message: ");
                string subject = Console.ReadLine();
                Console.Write("Write Your Message: ");
                string message = Console.ReadLine();
                Console.Write("Are You Sure? (Yes [y]) (No [n]): ");
                string confirm = Console.ReadLine().ToLower();
                if (confirm != "n" && confirm != "y")
                {
                    Console.WriteLine("Out of Range");
                    continue;
                }
                else if (confirm == "y")
                {
                    automation.SendMessage(new Message(DateTime.Now, subject, message, automation.CurrentUser, type));
                    Console.WriteLine("Successful!");
                }
                else
                {
                    continue;
                }
            }
        }
    }
}