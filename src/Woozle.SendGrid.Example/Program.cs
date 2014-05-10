using System;

namespace Woozle.SendGrid.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailSystem = new SendGridEMailSystem(new SendGridMail.SendGrid());
            emailSystem.SendEMail("<<your name>>", "<<your mail>>", "<<target mail>>", "<<mail title>>",
                "<<mail text>>");

            Console.ReadLine();
        }
    }
}
