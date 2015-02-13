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
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace pwdmanager
{
    /// <summary>
    /// Page4.xaml 的交互逻辑
    /// </summary>
    public partial class Page4 : Window
    {
        Socket c;
        public Page4()
        {
            InitializeComponent();
        }




            private void InitClient()
            {
                int port = 2000;
                string host = iphost.Text;
                IPAddress ip = IPAddress.Parse(host);
                IPEndPoint ipe = new IPEndPoint(ip, port);//把ip和端口转化为IPEndPoint实例
                c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建一个Socket

                ShowText("连接到Socket服务端...");

                c.Connect(ipe);//连接到服务器
            }


            private void ShowText(string text)
            {
                textshow.AppendText(text + "\n");
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    ShowText("发送消息到服务端...");
                    string sendStr = textBox2.Text;
                    //byte[] bs = Encoding.ASCII.GetBytes(sendStr);
                    byte[] bs = Encoding.UTF8.GetBytes(sendStr);

                    c.Send(bs, bs.Length, 0);

                    string recvStr = "";
                    byte[] recvBytes = new byte[1024];
                    int bytes;
                    bytes = c.Receive(recvBytes, recvBytes.Length, 0);//从服务器端接受返回信息
                    recvStr += Encoding.UTF8.GetString(recvBytes, 0, bytes);

                    ShowText("服务器返回信息：" + recvStr);
                }
                catch (ArgumentNullException ex1)
                {
                    Console.WriteLine("ArgumentNullException:{0}", ex1);
                }
                catch (SocketException ex2)
                {
                    Console.WriteLine("SocketException:{0}", ex2);
                }

            }

            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                InitClient();

            }
        }
        
    
}
