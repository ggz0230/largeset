using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class SendMailHelper
    {
        /// <summary>
        /// 使用smtp方式发送邮件
        /// </summary>
        /// <param name="toMails">收件人邮箱地址</param>
        /// <param name="host">SMTP服务器发送的地址和端口号   smtp.163.com,50</param>
        /// <param name="username">发送人邮箱地址</param>
        /// <param name="password">客户端授权码</param>
        /// <param name="subject">附件</param>
        /// <param name="body">正文</param>
        /// <param name="isBodyHtml">正文是否是html</param>
        /// <param name="filePaths">附件地址 绝对地址</param>
        public static void SendMailBySMTPANDPort(List<string> toMails, string host, string username, string password, string subject, string body, bool isBodyHtml, List<string> filePaths)
        {
            MailMessage msg = new MailMessage();
            foreach (var item in toMails)
            {
                msg.To.Add(new MailAddress(item));
            }
            msg.From = new MailAddress(username);
            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = isBodyHtml;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(username, password);
            client.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
            client.Host = host;
            if (host.Contains(','))
            {
                string[] arr = host.Split(',').ToArray();
                if (arr.Length == 2)
                {
                    client.Host = arr[0];
                    client.Port = Convert.ToInt32(arr[1]); // You can use Port 25 if 587 is blocked (mine is!)
                }
            }
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            //附件
            if (filePaths != null)
            {
                foreach (var filePath in filePaths)
                {
                    if (!string.IsNullOrWhiteSpace(filePath))
                    {
                        Attachment data = new Attachment(filePath, MediaTypeNames.Application.Octet);  //将文件进行转换成Attachments
                                                                                                       // Add time stamp information for the file.
                        ContentDisposition disposition = data.ContentDisposition;
                        disposition.CreationDate = System.IO.File.GetCreationTime(filePath);
                        disposition.ModificationDate = System.IO.File.GetLastWriteTime(filePath);
                        disposition.ReadDate = System.IO.File.GetLastAccessTime(filePath);
                        msg.Attachments.Add(data);
                        //System.Net.Mime.ContentType ctype = new System.Net.Mime.ContentType();
                    }
                }
            }

            client.Send(msg);
        }



        //下面的方法不重要了

        /// <summary>
        /// 使用smtp方式发送邮件
        /// </summary>
        /// <param name="toMails">收件人邮箱地址</param>
        /// <param name="host">SMTP服务器发送的地址 smtp.163.com</param>
        /// <param name="username">发送人邮箱地址</param>
        /// <param name="password">客户端授权码</param>
        /// <param name="subject">附件</param>
        /// <param name="body">正文</param>
        /// <param name="isBodyHtml">正文是否是html</param>
        /// <param name="filePaths">附件地址 绝对地址</param>
        public static void SendMailBySMTP(List<string> toMails, string host, string username, string password, string subject, string body, bool isBodyHtml, List<string> filePaths)
        {
            if (host == "smtp.office365.com")
            {
                SendBy365Office(toMails, host, username, password, subject, body, isBodyHtml, filePaths);
                return;
            }
            if (host == "smtp.163.com")
            {
                SendBy163(toMails, host, username, password, subject, body, isBodyHtml, filePaths);
                return;
            }
            if (host == "smtpcn01.huawei.com")
            {
                SendBy365Office(toMails, host, username, password, subject, body, isBodyHtml, filePaths);
                return;
            }
            using (MailMessage mailMessage = new MailMessage()) using (SmtpClient smtpClient = new SmtpClient(host))
            {
                foreach (var item in toMails)
                {
                    mailMessage.To.Add(item);
                }
                mailMessage.Body = body;
                mailMessage.From = new MailAddress(username);
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = isBodyHtml;

                if (filePaths != null)
                {
                    foreach (var filePath in filePaths)
                    {
                        if (!string.IsNullOrWhiteSpace(filePath))
                        {
                            Attachment data = new Attachment(filePath, MediaTypeNames.Application.Octet);  //将文件进行转换成Attachments
                                                                                                           // Add time stamp information for the file.
                            ContentDisposition disposition = data.ContentDisposition;
                            disposition.CreationDate = System.IO.File.GetCreationTime(filePath);
                            disposition.ModificationDate = System.IO.File.GetLastWriteTime(filePath);
                            disposition.ReadDate = System.IO.File.GetLastAccessTime(filePath);
                            mailMessage.Attachments.Add(data);
                            //System.Net.Mime.ContentType ctype = new System.Net.Mime.ContentType();
                        }
                    }
                }

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(username, password);//如果启用了“客户端授权码”，要用授权码代替密码  
                smtpClient.Send(mailMessage);
            }
        }

        public static void SendBy163(List<string> toMails, string host, string username, string password, string subject, string body, bool isBodyHtml, List<string> filePaths)
        {
            using (MailMessage mailMessage = new MailMessage()) using (SmtpClient smtpClient = new SmtpClient(host))
            {
                foreach (var item in toMails)
                {
                    mailMessage.To.Add(item);
                }
                mailMessage.Body = body;
                mailMessage.From = new MailAddress(username);
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = isBodyHtml;

                if (filePaths != null)
                {
                    foreach (var filePath in filePaths)
                    {
                        if (!string.IsNullOrWhiteSpace(filePath))
                        {
                            Attachment data = new Attachment(filePath, MediaTypeNames.Application.Octet);  //将文件进行转换成Attachments
                                                                                                           // Add time stamp information for the file.
                            ContentDisposition disposition = data.ContentDisposition;
                            disposition.CreationDate = System.IO.File.GetCreationTime(filePath);
                            disposition.ModificationDate = System.IO.File.GetLastWriteTime(filePath);
                            disposition.ReadDate = System.IO.File.GetLastAccessTime(filePath);
                            mailMessage.Attachments.Add(data);
                            //System.Net.Mime.ContentType ctype = new System.Net.Mime.ContentType();
                        }
                    }
                }
                smtpClient.Port = 25;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(username, password);//如果启用了“客户端授权码”，要用授权码代替密码  
                smtpClient.Send(mailMessage);
            }
        }

        public static void SendBy365Office(List<string> toMails, string host, string username, string password, string subject, string body, bool isBodyHtml, List<string> filePaths)
        {
            MailMessage msg = new MailMessage();
            foreach (var item in toMails)
            {
                msg.To.Add(new MailAddress(item));
            }
            msg.From = new MailAddress(username);
            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = isBodyHtml;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(username, password);
            client.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
            client.Host = host;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            //附件
            if (filePaths != null)
            {
                foreach (var filePath in filePaths)
                {
                    if (!string.IsNullOrWhiteSpace(filePath))
                    {
                        Attachment data = new Attachment(filePath, MediaTypeNames.Application.Octet);  //将文件进行转换成Attachments
                                                                                                       // Add time stamp information for the file.
                        ContentDisposition disposition = data.ContentDisposition;
                        disposition.CreationDate = System.IO.File.GetCreationTime(filePath);
                        disposition.ModificationDate = System.IO.File.GetLastWriteTime(filePath);
                        disposition.ReadDate = System.IO.File.GetLastAccessTime(filePath);
                        msg.Attachments.Add(data);
                        //System.Net.Mime.ContentType ctype = new System.Net.Mime.ContentType();
                    }
                }
            }

            client.Send(msg);
        }


    }
}
