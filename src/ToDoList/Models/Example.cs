using System;
using Twilio;

namespace ToDoList.Models
{
    class TwilioMessage
    {
        public TwilioMessage()
        {
        }

        public void SendJohnText(string item)
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account
            string AccountSid = "AC6324afe8d7eefea55b5cdd9fad49e7d0";
            string AuthToken = "1286dd457e686e5a0b26a5db28684f7c";

            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var message = twilio.SendMessage("+15036789613", "+19713134797", item, "");
        }
    }
}
