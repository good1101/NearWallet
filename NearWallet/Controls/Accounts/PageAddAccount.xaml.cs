using NearWallet.Entities;
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

namespace NearWallet.Controls.Accounts
{
    /// <summary>
    /// Логика взаимодействия для PageAddAccount.xaml
    /// </summary>
    public partial class PageAddAccount : PageControl
    {
        public PageAddAccount()
        {
            InitializeComponent();
            IsNavigate = true;
            cb_networks.Items.Clear();
            cb_networks.ItemsSource = Networks.NetworkConfigs.Select(a=> a.Value).OrderBy(a=>a.NetworkID);
            cb_networks.SelectedIndex = 0;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            object o = cb_networks.SelectedItem;
            string networkId = (cb_networks.SelectedItem as NetworkConfig).ToString();
            WalletNetwork wallet = Networks.GetNetwork(networkId);
            await wallet.AddAccount(tb_ID.Text, pass.Password);
            Networks.SetCurrent(
                new CurrentWallet
                {
                    AccountId = tb_ID.Text,
                    NetworkId = networkId

                });
            Back();
        }
    }
}
