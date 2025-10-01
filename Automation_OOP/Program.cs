// See https://aka.ms/new-console-template for more information
using Automation_OOP;

Automation automation = new Automation("Makeen", "Makeen Automation");
User user1 = new User("Ehsan", "Arefzadeh", User.type.Senior, "ehsan", "1234");
User user2 = new User("Ali", "Mehrabi", User.type.Junior, "ali_m", "1234");
User user3 = new User("Amin", "Rashidi", User.type.Senior, "amin_r", "1234");
Message message1 = new Message(DateTime.Now, "Tets 1", "This is a test meassage", user1, user2);
Message message2 = new Message(DateTime.Now, "Tets 2", "This is a test meassage", user2, user1);
Message message3 = new Message(DateTime.Now, "Tets 3", "This is a test meassage", user2, User.type.Senior);
automation.AddUsers(user1);
automation.AddUsers(user2);
automation.AddUsers(user3);
automation.SendMessage(message1);
automation.SendMessage(message2);
automation.SendMessage(message3);
//------------------------------------------------
Responsive.Login(automation);
bool appRun = true;
while (appRun)
{
    Console.Write("[1]SentMeassages / [2]ReceivedMessages / [3]SendMessage(User) / [4]SendMessage(Group) / [5]Exit -- Choose: ");
    switch (Console.ReadLine())
    {
        case "1":
            Responsive.GetSentMessages(automation);
            break;
        case "2":
            Responsive.GetReceiveMessages(automation);
            break;
        case "3":
            Responsive.SendMessageUser(automation);
            break;
        case "4":
            Responsive.SendMessageGroup(automation);
            break;
        case "5":
            appRun = false;
            break;
    }
}
