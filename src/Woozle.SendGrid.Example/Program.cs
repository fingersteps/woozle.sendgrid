using System;
using Woozle.Domain.ExternalSystem.Mail;

namespace Woozle.SendGrid.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailSystem = new SendGridEMailSystem
                              {
                                  Credentials =
                                  {
                                      Username = "<<put your username here>>",
                                      Password = "<<put your password here>>"
                                  }
                              };

            emailSystem.SendEMail("<<your name>>", "<<your mail>>", "<<target mail>>", "<<mail title>>",
                "<<mail text>>");

            Console.ReadLine();
        }
    }
}
