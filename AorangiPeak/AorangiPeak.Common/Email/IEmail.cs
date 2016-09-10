using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AorangiPeak.Common.Email
{
    public interface IEmail
    {
        void SendEmail(string to, string subject, string message);
        void SendEmail(string to, string cc, string bcc, string subject, string message);
        void SendIndiviualEmailPerRecipient(string[] to,string subject, string message);
    }
}
