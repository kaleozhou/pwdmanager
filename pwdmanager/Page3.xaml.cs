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
using System.Windows.Threading;
using System.Threading;

namespace pwdmanager
{
    /// <summary>
    /// Page3.xaml 的交互逻辑
    /// </summary>
    public partial class Page3 : Window
    {
        SocketListener listener;
        public Page3()
        {
            InitializeComponent();
            InitServer();
        }


        private void InitServer()
        {
            System.Timers.Timer t = new System.Timers.Timer(2000);
            //实例化Timer类，设置间隔时间为5000毫秒；
            t.Elapsed += new System.Timers.ElapsedEventHandler(CheckListen);
            //到达时间的时候执行事件； 
            t.AutoReset = true;
            t.Start();
        }

        private void CheckListen(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (listener != null && listener.Connection != null)
            {
                //label2.Content = listener.Connection.Count.ToString();
                //ShowText("连接数：" + listener.Connection.Count.ToString());
            }
        }

      

        private void SocketListen()
        {
            listener = new SocketListener();
            listener.ReceiveTextEvent += new SocketListener.ReceiveTextHandler(ShowText);
            listener.StartListen();
        }

        public delegate void ShowTextHandler(string text);
        ShowTextHandler setText;

        private void ShowText(string text)
        {
            if (System.Threading.Thread.CurrentThread != txtSocketInfo.Dispatcher.Thread)
            {
                if (setText == null)
                {
                    setText = new ShowTextHandler(ShowText);
                }
                txtSocketInfo.Dispatcher.BeginInvoke(setText, DispatcherPriority.Normal, new string[] { text });
            }
            else
            {
                txtSocketInfo.AppendText(text + "\n");
            }
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Page4 client = new Page4();
            client.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Thread th = new Thread(new ThreadStart(SocketListen));
            th.Start();

        }
    }
}
