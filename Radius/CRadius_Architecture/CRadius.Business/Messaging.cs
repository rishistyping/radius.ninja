using Sodium.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace CRadius.Business
{
    public class Messaging
    {
        #region Fields

        string connectionStringName = string.Empty;

        string _from = "bucket@mineral.blue"; // R088ieR0bot
        string _fromName = "Coronalert";
        string _sendGridUsername = "apikey";
        string _sendGridPassword = "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";
        string _sendGridSMTP = "smtp.sendgrid.net";

        int _sendGridPort = 587;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Messaging class.
        /// </summary>
        public Messaging(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);
			this.connectionStringName = connectionStringName;
		}

        #endregion

        #region Properties

        #endregion

        #region Methods

        public void SendErrorEmail(
            List<string> lines,
            string path)
        {
            // Build and write the body
            string message = string.Empty;
            foreach (string line in lines) message += line;

            Mail("Coronalert Error: " + path, "bucket@mineral.blue", "bucket@mineral.blue", message);
        }


        public string Mail(
            string subject,
            string to,
            string toName,
            string message)
        {
            string errorMessage = string.Empty;

            if (to.Length > 0)
            {
                Thread myThread = new Thread(delegate ()
                {
                    try
                    {
                        MailMessage mail = new MailMessage();

                        if (toName.Length > 0) mail.To.Add(new MailAddress(to, toName));
                        else mail.To.Add(new MailAddress(to));

                        mail.From = new MailAddress(_from, _fromName);
                        mail.Subject = subject;

                        string plain = subject;
                        mail.IsBodyHtml = true;

                        AlternateView plainView = AlternateView.CreateAlternateViewFromString(plain, null, "text/plain");
                        mail.AlternateViews.Add(plainView);

                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(message, null, "text/html");
                        mail.AlternateViews.Add(htmlView);

                        SmtpClient smtpClient = new SmtpClient(_sendGridSMTP, _sendGridPort);
                        smtpClient.Credentials = new NetworkCredential(_sendGridUsername, _sendGridPassword);
                        smtpClient.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                });
                myThread.Start();
            }

            return errorMessage;
        }



        #endregion
    }
}
