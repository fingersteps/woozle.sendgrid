using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using SendGridMail;
using Woozle.Domain.ExternalSystem;
using Woozle.Domain.ExternalSystem.Mail;

namespace Woozle.SendGrid
{
    [Export(typeof(IExternalMailSystem))]
    [ExternalSystem(Name = "SendGridEMailSystemV1")]
    public class SendGridEMailSystem : IExternalMailSystem
    {
        private readonly ISendGrid sendGrid;

        public SendGridEMailSystem()
        {
            this.sendGrid = SendGridMail.SendGrid.GetInstance();
        }

        public bool SendEMail(string fromName, string fromAddress, string toAddress, string subject, string text)
        {
            if (string.IsNullOrEmpty(fromAddress) || string.IsNullOrEmpty(toAddress)) return false;

            try
            {
                // Create the email object first, then add the properties.
                sendGrid.From = new MailAddress(fromAddress, fromName);
                sendGrid.AddTo(toAddress);
                sendGrid.Subject = subject;
                sendGrid.Text = text;

                SendMail(sendGrid);

                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return false;
            }
        }

        public ExternalMailSystemCredentials Credentials { get; set; }

        private void SendMail(ISendGrid sendGrid)
        {
            // Create credentials, specifying your user name and password.
            var credentials = new NetworkCredential(
                this.Credentials.Username, 
                this.Credentials.Password);

            // Create an SMTP transport for sending email.
            var transportSMTP = Web.GetInstance(credentials);

            // Send the email.
            transportSMTP.Deliver(sendGrid);
        }
    }
}
