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
using System.IO;

namespace pwdmanager
{
    /// <summary>
    /// Page2.xaml 的交互逻辑
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            //获取文件名称
            string fileName = FileNameTextBox.Text.Trim();
            //获取主机名称
            string HostName = IPTextBox.Text.Trim();
            //获取端口号
            int port = Int32.Parse(PortTextBox.Text.Trim());
            //得到主机信息
            IPHostEntry ipInfor = Dns.Resolve(HostName);
            //获取IP地址Address[]
            IPAddress[] ipAddr = ipInfor.AddressList;
            //获得IP
            IPAddress ip = ipAddr[0];
            //组合出远程终点
            IPEndPoint hostEP = new IPEndPoint(ip, port);
            //创建Socket实例
            Socket socket = new Socket(AddressFamily.InterNetwork, 
                                        SocketType.Stream, ProtocolType.Tcp);
            try 
            {
                //尝试连接
                socket.Connect(hostEP);
            }
            catch(Exception  ex)
            {
                MessageBox.Show( "连接错误："+ex.Message, "提示信息",MessageBoxButton.OK);
            }
            //发送给远程主机的请求内容串    
            string sendStr = "GET / HTTP/1.1/r/nHost: " + HostName +
                                "/r/nConnection: Close/r/n/r/n";    
            //创建一个byte数组用以转发数据字符串
            byte[] bytesSendStr = new byte[1024];
            //把转发字符串转化为byte字符数据
            bytesSendStr = System.Text.Encoding.ASCII.GetBytes(sendStr.ToCharArray());
            try 
            {
                //向主机发送请求
                socket.Send(bytesSendStr,bytesSendStr.Length,0);
            }
            catch(Exception ce)
            {             
                MessageBox.Show("发送错误:"+ce.Message,"提示信息",
                                MessageBoxButton.OK);    
            }

            //创建接收字符串
            string recvStr = "";
            //创建接收byte数组,一次接收1024个字节
            byte[] recvByte = new byte[1024];
            //声明实际接收字节数
            int bytes = 0;
            while (true) 
            {
                //接收数据
                bytes = socket.Receive(recvByte, recvByte.Length, 0);
                if (bytes <= 0) 
                {
                    break;
                }
                //把接收到的数据转化成UTF-8的编码字符串
                recvStr += System.Text.Encoding.Unicode.GetString(recvByte);
            }
            //把读取的字符串转化为字符数组
            
            byte[] content = System.Text.Encoding.Unicode.GetBytes(recvStr.ToCharArray());
            try 
            {
                //创建文件流对象
                FileStream fileStr = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                //写入文件
                fileStr.Write(content, 0, content.Length);
                //把文件用浏览器打开
                System.Diagnostics.Process.Start("IExplore.exe", fileName);
            }
            catch(Exception fe)
            {
                MessageBox.Show("文件创建/写入错误:" + fe.Message, "提示信息", MessageBoxButton.OK);    

            }
            //禁用soket
            socket.Shutdown(SocketShutdown.Both);
            //关闭socket
            socket.Close();
        }
    }
}

