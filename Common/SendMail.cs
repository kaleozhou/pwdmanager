/* ==============================
*
* Author: 周衍鹏
* Time：2015/1/10 19:26:43
* FileName：SendMail
* Version：V1.0.1
* ===============================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Data;
using System.Configuration;
using System.Web;

using System.Net;
using System.Net.Mail;
using System.Net.Mime;
namespace Maticsoft.Common
{
    /// <summary>
    /// 发送邮件类的摘要说明
    /// </summary>
   public class SendMail
    {
        static readonly string smtpServer = System.Configuration.ConfigurationManager.AppSettings["SmtpServer"];
        static readonly string userName = System.Configuration.ConfigurationManager.AppSettings["UserName"];
        static readonly string pwd = System.Configuration.ConfigurationManager.AppSettings["Pwd"];
        static readonly int smtpPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpPort"]);
        static readonly string authorName = System.Configuration.ConfigurationManager.AppSettings["AuthorName"];
        static readonly string to = System.Configuration.ConfigurationManager.AppSettings["To"];
        /// <param name="fileName">附件(多附件请用;分隔,单个附件请不要超过20M)</param>
        public SendMail()
        {
        }
        /// <summary>
        /// C# 发送邮件，通过测试sina，smtp服务器成功发送
        /// </summary>
        /// <param name="m_file">邮件附件的地址包括文件名称(多附件请用;分隔,单个附件请不要超过20M)</param>
        public void send(string m_file ,string subject,string body)
        {

            #region//设置邮件信息
            MailMessage message = new MailMessage();//实例化邮件主体
            message.From = new MailAddress(userName+"@qq.com", authorName);//发信人地址
            message.To.Add(new MailAddress(to, authorName));//收信人地址
            message.Subject = subject;//邮件主题
            message.Body = body;//邮件主体：正文
            message.IsBodyHtml = true;//主体是否是html格式
            #endregion
            #region//获取所有邮件附件
            char[] cr = { ';' };
            string[] file = m_file.Split(cr);
            for (int n = 0; n < file.Length; n++)
            {
                if (file[n] != "")
                {
                    //附件对象
                    Attachment data = new Attachment(file[n], MediaTypeNames.Application.Octet);
                    //附件资料
                    ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(file[n]);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(file[n]);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(file[n]);
                    //加入邮件附件
                    message.Attachments.Add(data);
                }
            }
            #endregion
            #region//设置发送邮件的smtp服务器信息
            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();//实例化发送邮件的smtp服务器
            smtpClient.Host = smtpServer;//服务器的名称
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定处理邮件的方式，此处为通过网络发送到smtp服务器
            smtpClient.Credentials = new System.Net.NetworkCredential(userName, pwd);//验证发件人身份，用户名kaixiyeetop，密码******
            try
            {
                smtpClient.Send(message);//发送邮件
                //  System.Windows.Forms.MessageBox.Show("发送邮件成功！");
            }
            catch (Exception ex)
            {
                // System.Windows.Forms.MessageBox.Show(ex.Message);

            }

            #endregion
        }
        public void send(string m_file, string subject, string body,string to)
        {

            #region//设置邮件信息
            MailMessage message = new MailMessage();//实例化邮件主体
            message.From = new MailAddress(userName + "@qq.com", authorName);//发信人地址
            var tolist = to.Split(',');
            foreach (var item in tolist)
            {
                message.To.Add(new MailAddress(item, authorName));//收信人地址
                
            }
            //message.To.Add(new MailAddress(to, authorName));//收信人地址
            message.Subject = subject;//邮件主题
            message.Body = body;//邮件主体：正文
            message.IsBodyHtml = true;//主体是否是html格式
            #endregion
            #region//获取所有邮件附件
            char[] cr = { ';' };
            string[] file = m_file.Split(cr);
            for (int n = 0; n < file.Length; n++)
            {
                if (file[n] != "")
                {
                    //附件对象
                    Attachment data = new Attachment(file[n], MediaTypeNames.Application.Octet);
                    //附件资料
                    ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(file[n]);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(file[n]);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(file[n]);
                    //加入邮件附件
                    message.Attachments.Add(data);
                }
            }
            #endregion
            #region//设置发送邮件的smtp服务器信息
            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();//实例化发送邮件的smtp服务器
            smtpClient.Host = smtpServer;//服务器的名称
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定处理邮件的方式，此处为通过网络发送到smtp服务器
            smtpClient.Credentials = new System.Net.NetworkCredential(userName, pwd);//验证发件人身份，用户名kaixiyeetop，密码******
            try
            {
                smtpClient.Send(message);//发送邮件
                //  System.Windows.Forms.MessageBox.Show("发送邮件成功！");
            }
            catch (Exception ex)
            {
                // System.Windows.Forms.MessageBox.Show(ex.Message);

            }

            #endregion
        }
    }
}