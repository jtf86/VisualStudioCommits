using System;
using ToDoList;
using Twilio;

namespace ToDoList.Models
{
    class TwilioMessage
    {
        public TwilioMessage()
        {
        }

        public void SendAlertText(string item)
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account
            string AccountSid = "AC6324afe8d7eefea55b5cdd9fad49e7d0";
            string AuthToken = (new AuthToken().token);

            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var message = twilio.SendMessage("+15036789613", "+19713134797", item, "");
        }
    }
}
