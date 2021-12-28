using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace NearWallet.Controls
{
    /// <summary>
    /// Логика взаимодействия для MessageView.xaml
    /// </summary>
    public partial class MessageView : UserControl
    {
        public MessageView(string header, string messgae)
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(10);
            _timer.Tick += _timer_Tick;
            _timer.Start();
            tb_header.Text = header;
            tb_text.Text = messgae;
        }

        DispatcherTimer _timer;
        public Action EndView { get; set; }

        private void _timer_Tick(object sender, EventArgs e)
        {
            EndView?.Invoke();
            _timer.Stop();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EndView?.Invoke();
            _timer.Stop();
        }
    }
}
