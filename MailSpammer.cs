using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Sockets;
using System.Net;
using System.Net.Http;
using System.Diagnostics.Eventing.Reader;

namespace Tut_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title  = "Mail Spammer 1.0 by ElpersonPL";
            Console.WriteLine("Login:");
            string login = Console.ReadLine();
            Console.WriteLine("Hasło / Password?");
            string haslo = Console.ReadLine();
            Console.WriteLine("Tekst w  wiadomości? / Mail text?");
            string text = Console.ReadLine();
            Console.WriteLine("Adres osoby odbierającej ? / Receiver email");
            string dokogo = Console.ReadLine();
            
            Console.WriteLine("Ile maili? / How many mails?");
            int ilosc = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= ilosc; i++)
            {
                mailSender(login, haslo, text, dokogo);
            }

           
            
            



        }

        
        static void mailSender(string loggin,string passwd, string Message, string MailTo)
        {
            
            // Losowy temat by zapełnić skrzynke
            
            Random subject = new Random();
            int sub = subject.Next(1, 500);
            string subbo = sub.ToString();


            // Połącz się z serwerem

            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.EnableSsl = true;
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.UseDefaultCredentials = false;
            NetworkCredential pass = new NetworkCredential(loggin, passwd);
            MailMessage Mail = new MailMessage();
            SmtpServer.Credentials = pass;
            
            // Rzeczy o mailu
            
            Mail.From = new MailAddress(loggin);
            Mail.To.Add(MailTo);
            Mail.Subject = subbo;
            Mail.Body = Message;
            // Wysyłanie
            SmtpServer.Send(Mail);
            Console.WriteLine("Sent!");
        }


    }
    


}
