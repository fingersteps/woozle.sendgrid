using System;

namespace Woozle.SendGrid.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailSystem = new SendGridEMailSystem(SendGridMail.SendGrid.GetInstance(), new SendGridCredentials());
            emailSystem.SendEMail("<<your name>>", "<<your mail>>", "<<target mail>>", "<<mail title>>",
                "<<mail text>>");

            Console.ReadLine();
        }
    }
}
