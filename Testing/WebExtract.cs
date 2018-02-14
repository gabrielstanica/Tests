using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WhatsAppApi;
using Facebook;
using System.Net.Mail;

namespace Testing
{
    class WebExtract
    {

        public static void Page_Load()
        {
            string Url = "http://api.kissfm.ro/api/articole/comments/7047";
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(Url);

                //var text = doc.DocumentNode.FirstChild.InnerText;
                //var text2 = doc.DocumentNode.FirstChild.InnerHtml
                WebClient wc = new WebClient();
            byte[] b;
            b = wc.DownloadData(Url);
            int count = 0;
            do
            {

                var text = Encoding.UTF8.GetString(b);
                if(text.ToLower().Contains("byo"))
                {
                    Console.WriteLine("Found");
                    string[] want = new string[] { "{\"id\"" };
                    var list = Regex.Match(text.ToLower(), "{\"id\"" +".+(byo).+\"").Value.Split(want, StringSplitOptions.RemoveEmptyEntries).ToList().Find(item => item.Contains("byo"));
                    var timestamp = Regex.Match(list, "timestamp\":.+,").Value;
                    var index = timestamp.Substring(timestamp.LastIndexOf(":")+1, timestamp.Length - timestamp.LastIndexOf(":")-2);
                    var date = UnixTimeStampToDateTime(Convert.ToDouble(index));

                    Console.WriteLine("Text found at " + date + " " + list);
                    string from = "733766829";
                    string toMe = "733766829";
                    string message = "Win";
                    string email = "gabriel.stanica92@gmail.com";
                    string country = "40";

                    SendSMS(toMe, message, email, country);
                    break;
                }

                var s = "more_url"; var pattern = String.Format("{0}.+", s);
                var g = Regex.Match(text, @pattern + ".\"}");
                var sub = g.Groups[0].Value;
                var search = sub.Substring(sub.IndexOf("http"), sub.Length - sub.IndexOf("http") - 2).Replace(@"\", "");
                b = wc.DownloadData(search);
                count++;
            } while (b.Count() > 0&& count <= 50);

        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static void SendWhapp()
        {
            string from = "40733766829";
            string toMishu = "4073100090";
            string to = "40733766829";
            string message = "Hey";
            string imei = "354378062812286";
            string password = "UkBynPbG19MK9kVvhSjpfJ22HqQ=";
            string nick = "Test";

            //var by = new byte[] { Convert.ToByte(imei) };
            //var base64 = Convert.ToBase64String(by);
            WhatsApp wa = new WhatsApp(from, imei, nick, true, true);

            wa.OnConnectSuccess += () =>
            {
                Console.WriteLine("Connected");
                wa.OnLoginSuccess += (phoneNumber, data) =>
                {
                    wa.SendMessage(to, message);
                    Console.WriteLine("Message send");
                };

                wa.OnLoginFailed += (data) =>
                {
                    Console.WriteLine("Fail to send");
                };

                wa.Login();
            };

            wa.OnConnectFailed += (ex) =>
            {
                Console.WriteLine("Failed to connect");
            };

            wa.Connect();
        }

        public static void SendGmailMail()
        {
            var fromAddress = new MailAddress("gabriel.stanica92@gmail.com", "From Name");
            var toAddress = new MailAddress("gabriel.stanica92@gmail.com", "To Name");
            const string fromPassword = "Casio2992";
            const string subject = "Subject";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

        }

        public static void SendSMS(string number, string message, string email, string countrycode)
        {
            try
            {
                SmsTest.com.webservicex.www.SendSMSWorld smsWorld =
                  new SmsTest.com.webservicex.www.SendSMSWorld();

                    smsWorld.sendSMS(email,countrycode, number, message);
                Console.WriteLine("Message Send Succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Sending message" + ex.ToString());
            }
        }
    }
}
