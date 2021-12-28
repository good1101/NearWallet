using NearWallet.Entities.Network;
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

namespace NearWallet.Controls.Settings
{
    /// <summary>
    /// Логика взаимодействия для PageAddNetwork.xaml
    /// </summary>
    public partial class PageAddNetwork : PageControl
    {
        public PageAddNetwork()
        {
            InitializeComponent();
            IsNavigate = true;
        }

        private async void Add(object sender, RoutedEventArgs e)
        {
            Networks.AddNetwork(new NetworkConfig()
            {
                NetworkID = tb_NameNetwork.Text,
                NodeUrl = tb_rpc.Text
            });
            await MainWindow.Alert("Added new network.");
            Back();
        }
    }
}
