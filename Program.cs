using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

System.Console.WriteLine("What crn would you like to check?");
string crnInput = Console.ReadLine();

System.Console.WriteLine("Type in the email you would like to use and hit enter");
string toEmail = Console.ReadLine();

WebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl("https://ssb.ua.edu/pls/PROD/ua_bwckschd.p_disp_detail_sched?term_in=202310&crn_in=" + crnInput);

regChecker(toEmail, driver);






static void fileChecker(string toEmail, WebDriver driver){
    StreamReader inFile = new StreamReader("output.txt");
    string line = inFile.ReadLine();
    if(int.Parse(line) > 0)
    {
        SendMail(toEmail);
        driver.Close();
    }else
    {
        regChecker(toEmail, driver);
    }
}


static void regChecker(string toEmail, WebDriver driver)
{
    var content = driver.FindElement(By.XPath("/html/body/div[3]/table[1]/tbody/tr[2]/td/table[1]/tbody/tr[2]/td[3]"));
    StreamWriter outFile = new StreamWriter("output.txt");
    outFile.WriteLine(content.Text);
    outFile.Close();
    driver.Navigate().Refresh();
    
    System.Threading.Thread.Sleep(60000);
    fileChecker(toEmail, driver);
}





















// driver.FindElement(By.Id("login-username")).SendKeys("hudsonab123@gmail.com");
// driver.FindElement(By.Id("login-password")).SendKeys("jojwor-woMxy9-wetkix");
// driver.FindElement(By.Id("login-button")).Click();
// System.Threading.Thread.Sleep(4000);
// driver.FindElement(By.ClassName("Button-y0gtbx-0")).Click();
// System.Threading.Thread.Sleep(10000);
// //write the result of the element "link-subtle" to a text file
// string output = "";
// driver.FindElement(By.ClassName("link-subtle")).Text();



static void SendMail(string toEmail)
{
    MailMessage mail = new MailMessage();
    
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
    


