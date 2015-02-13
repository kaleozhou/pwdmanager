using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

using Maticsoft;
namespace pwdmanager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑 2015年2月12日12:50:00
    /// </summary>
    public partial class MainWindow : Window
    {
        string filepath = "";
        Maticsoft.BLL.userman userman_bll = new Maticsoft.BLL.userman();
        Maticsoft.BLL.accountinfo accountinfo_bll = new Maticsoft.BLL.accountinfo();
        public MainWindow()
        {
            InitializeComponent();
        }
        //登录按钮事件 周衍鹏 2015年2月11日19:33:07
        private void Button_login_Click(object sender, RoutedEventArgs e)
        {
            string username = TextBox_username.Text;
            string userpwd = PasswordBox_password.Password;
                
            var listmodel= userman_bll.GetModelList("UserManName='" + username + "' and UserManPwd='"+userpwd+"'");
           
            if (listmodel.Count>0)
	        {
                Maticsoft.Model.userman userman_model=listmodel.First();
                if (userman_model != null)
                {
                    MessageBox.Show("恭喜你登录成功！");

                  
                }
	        }
            else
            {
              
                MessageBox.Show("您的用户名或密码不正确！");
            }

        }
      
        public int SendMail(string filepath, string subject,string body,string to) {

            int res = 0;
           

              Maticsoft.Common.SendMail sendmail = new Maticsoft.Common.SendMail();
              sendmail.send(filepath, subject, body, to);
            
            return res;
        }

        private void Button_mail_send_Click(object sender, RoutedEventArgs e)
        {
            string subject = mail_subject.Text;
            string body = mail_body.Text;
            string to = mail_to.Text;

            int res=SendMail(filepath, subject, body, to);
            if (res==0)
            {
                MessageBox.Show("邮件发送成功");
                
            }
            else
            {
                MessageBox.Show("邮件发送失败");

            }
        }

        private void Button_mail_file_Click(object sender, RoutedEventArgs e)
        {
           
            //弹出文件选择框
            OpenFileDialog open = new OpenFileDialog();//定义打开文本框实体
            open.Title = "选择附件";//对话框标题
            open.Filter = "All（.*）|*.*";//文件扩展名
            if ((bool)open.ShowDialog().GetValueOrDefault())//打开
            {
                filepath = open.FileName;
            }
        }

     
      
    }
}
