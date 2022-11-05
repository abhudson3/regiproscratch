using System.Net;
using System.Net.Mail;
//plan - use selenium to periodically refresh with a time out of 60000
//run the scraper to get the input
//
static void SendMail()
{
    MailMessage mail = new MailMessage();
    System.Console.WriteLine("Type in the email you would like to use and hit enter");
    string toEmail = Console.ReadLine();
    
    
    mail.From = new MailAddress("regiprotest2@gmail.com");
    mail.To.Add(toEmail);
    mail.Subject = "Class drop notification";
    mail.Body = "Class has an open slot";
    
    SmtpClient SmtpServer = new SmtpClient();
    SmtpServer.Host = "smtp.gmail.com";
    SmtpServer.Port = 587;
    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
    SmtpServer.Credentials = new NetworkCredential("regiprotest2@gmail.com", "stsjpserbidjwwby");
    SmtpServer.Timeout = 20000;
    SmtpServer.EnableSsl = true;

    SmtpServer.Send(mail);
}
    


