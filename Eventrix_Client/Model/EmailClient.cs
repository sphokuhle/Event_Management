using Eventrix_Client.Model.ClientDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace Eventrix_Client.Model
{
    public class EmailClient
    {
        //Sending survey emails to guest
        public void sendSurvey(string Name,string Email, EventModel _event)
        {
            EventAddress addres = new EventAddress();
            MappingClient add_client = new MappingClient();
            addres = add_client.getAddressById(Convert.ToString(_event.EventAddress));

            EventHostModel host = new EventHostModel();
            HostServiceClient ev_host = new HostServiceClient();
            host = ev_host.findhsotbyID(Convert.ToString(_event.HostID));
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("tnteventrix@gmail.com", "201313286@student.uj.ac.za");
            smtp.EnableSsl = true;

            MailMessage msg = new MailMessage();
            msg.Subject = "Post Event Survey for " + _event.Name;
            msg.Body = "Hi " + Name + ",";
            msg.Body += "<tr><td>On behalf of TNT Eventrix and "+_event.Name+", we would like to thank you for taking part.</td></tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>Would you take 3 minutes of your time and complete the very breif survey and help us help you in improving your satisfaction for our next event?</td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>Kindly <a href='http://localhost:60469/Login.aspx?e_ID=" + _event.EventID + " &purp=surv'>click here</a> to fill the short survey.</td>";
            msg.Body += "</tr>";
            
            msg.Body += "<tr>";
            msg.Body += "<td>Sincerely,</td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>TNT Eventrix </td>";    //Event host name
            msg.Body += "</tr>";
            //      see http://msdn.microsoft.com/de-de/library/system.net.mime.mediatypenames.application.aspx
            //Attachment data = new Attachment(
            //"C:/Users/Admin/Desktop/Email/EmailOne/BigBite.jpg",
            //MediaTypeNames.Application.Octet);
            // your path may look like Server.MapPath("~/file.ABC")
            //msg.Attachments.Add(data);
            string toAddress = Email; // Add Recepient address
            msg.To.Add(toAddress);
            msg.To.Add(new MailAddress(toAddress));

            string FromAddress = "tnteventrix@gmail.com";
            msg.From = new MailAddress(FromAddress);
            msg.IsBodyHtml = true;

            try
            {
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        //Sending Invitation
        public void sendMsgInvite( GuestModel _guest, EventModel _event, string pass, int EventID)
        {
            EventAddress addres = new EventAddress();
            MappingClient add_client = new MappingClient();
            addres = add_client.getAddressById(Convert.ToString(_event.EventAddress));

            EventHostModel host = new EventHostModel();
            HostServiceClient ev_host = new HostServiceClient();
            host  = ev_host.findhsotbyID(Convert.ToString(_event.HostID));
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("tnteventrix@gmail.com", "201313286@student.uj.ac.za");
            smtp.EnableSsl = true;

            MailMessage msg = new MailMessage();
            msg.Subject = "Invitation to the " + _event.Name;
            msg.Body = "Hi " + _guest.NAME + ",";
            msg.Body += "<tr><td>EventriX would like to invite you to attend the " + _event.Desc + "</td></tr>";
            msg.Body += "<tr>";
            msg.Body += "<td><img src='" + _event.ImageLocation + "' alt=''/></td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>" + _event.eDate + "</td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td> Location: " + addres.STREET + ", " + addres.CITY + ", " + addres.PROVINCE+ "</td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            //http://localhost:60469/Login.aspx?e_ID=
            //
            msg.Body += "<td>To RSVP please <a href='http://localhost:60469/Login.aspx?e_ID=" + EventID + "'>click here</a> and use the following details</td>"; //Update Link
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>Username: " + _guest.EMAIL + "</td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>One Time Password: "+ pass + " </td>";    //need to generate OTP
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>Sincerely,</td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>TNT Eventrix </td>";    //Event host name
            msg.Body += "</tr>";
            //      see http://msdn.microsoft.com/de-de/library/system.net.mime.mediatypenames.application.aspx
            //Attachment data = new Attachment(
                                     //"C:/Users/Admin/Desktop/Email/EmailOne/BigBite.jpg",
                                     //MediaTypeNames.Application.Octet);
            // your path may look like Server.MapPath("~/file.ABC")
            //msg.Attachments.Add(data);
            string toAddress = _guest.EMAIL; // Add Recepient address
            msg.To.Add(toAddress);
            msg.To.Add(new MailAddress(toAddress));

            string FromAddress = "tnteventrix@gmail.com";
            msg.From = new MailAddress(FromAddress);
            msg.IsBodyHtml = true;

            try
            {
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        //Sending Email with the purchased Qr-Code
        public void sendMsg_TicketPurchased(string GuestName, string GuestEmail, EventModel _event, QRCodeImage QRCode, EventTicket ticket)
        {

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("tnteventrix@gmail.com", "201313286@student.uj.ac.za");
            smtp.EnableSsl = true;

            MailMessage msg = new MailMessage();
            msg.Subject = "Ticket Purchased for " + _event.Name;
            msg.Body = "Hi " + GuestName + ",";
            msg.Body += "<tr><td>Herewith purchased Ticket for :" + _event.Name + "</td></tr>";
            msg.Body += "<tr>";
            msg.Body += "<td><img src='" + _event.ImageLocation + "' alt=''/></td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>" + _event.eDate + "</td>";
            msg.Body += "</tr>";
            //msg.Body += "<tr>";
            //msg.Body += "<td>" + _event.Eve + "</td>";
            //msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>Ticket Details: </td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>Type: " + ticket._Type + "</td>";     //Ticket Type
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>Credit: " + ticket._Credit + "</td>"; //Credits
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>Sincerely,</td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>Eventrix</td>";    //Event Host Name
            msg.Body += "</tr>";
            
            Attachment data = new Attachment(
                                    QRCode.Location,
                                     MediaTypeNames.Application.Octet);
            // your path may look like Server.MapPath("~/file.ABC")
            msg.Attachments.Add(data);
            string toAddress = GuestEmail; // Add Recepient address
            msg.To.Add(toAddress);
            msg.To.Add(new MailAddress(toAddress));

            string FromAddress = "tnteventrix@gmail.com";
            msg.From = new MailAddress(FromAddress);
            msg.IsBodyHtml = true;

            try
            {
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        //Sending Email For Successful Registration
        public void sendMsg_SuccessRegistration(GuestModel _guest)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("tnteventrix@gmail.com", "201313286@student.uj.ac.za");
            smtp.EnableSsl = true;

            MailMessage msg = new MailMessage();
            msg.Subject = "Welcome to EventriX";
            msg.Body = "Hi " + _guest.NAME + ",";
            msg.Body += "<tr><td>Thank you for signing up with Eventrix, Now you can browse, select and purchase";
            msg.Body += "tickets for the events best suited for you.</td></tr>";
            msg.Body += "<td>Please <a href='http://localhost:60469/Login.aspx'>click here</a> To Login</td>"; //Update Link
            msg.Body += "<tr>";
            msg.Body += "<td>Sincerely,</td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>TNT EventriX</td>";
            msg.Body += "</tr>";
          
            string toAddress = _guest.EMAIL; // Add Recepient address
            msg.To.Add(toAddress);
            msg.To.Add(new MailAddress(toAddress));

            string FromAddress = "tnteventrix@gmail.com";
            msg.From = new MailAddress(FromAddress);
            msg.IsBodyHtml = true;

            try
            {
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        //Sending Email For Successful Registration
        public void sendMsg_SuccessRegistration(EventHostModel _host)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("tnteventrix@gmail.com", "201313286@student.uj.ac.za");
            smtp.EnableSsl = true;

            MailMessage msg = new MailMessage();
            msg.Subject = "Welcome to EventriX";
            msg.Body = "Hi " + _host.NAME + ",";
            msg.Body += "<tr><td>Thank you for signing up with Eventrix, Now you can create, browse and manage your events and so much more.</td></tr>";
            msg.Body += "<td>Please <a href='http://localhost:60469/Login.aspx'>click here</a> To Login</td>"; //Update Link
            msg.Body += "<tr>";
            msg.Body += "<td>Sincerely,</td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>TNT EventriX</td>";
            msg.Body += "</tr>";

            string toAddress = _host.EMAIL; // Add Recepient address
            msg.To.Add(toAddress);
            msg.To.Add(new MailAddress(toAddress));

            string FromAddress = "tnteventrix@gmail.com";
            msg.From = new MailAddress(FromAddress);
            msg.IsBodyHtml = true;

            try
            {
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

    }
}