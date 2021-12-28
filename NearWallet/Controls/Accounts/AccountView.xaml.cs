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
    /// Логика взаимодействия для AccountView.xaml
    /// </summary>
    public partial class AccountView : UserControl
    {
        public AccountView(string accountId, string networkId)
        {
            InitializeComponent();
            if (accountId != Networks.CurrentAccountId)
                rectIcon.Fill = null;
            _accountId = accountId;
            _networkId = networkId;
            tb_idAccount.Text = accountId;
            tb_networkId.Text = networkId;

        }
        public Action OnSelected { get; set; }
        public Action OnRemove { get; set; }
        string _accountId;
        string _networkId;

        private void Selected(object sender, MouseButtonEventArgs e)
        {
            Networks.SetCurrent(new CurrentWallet
            {
                AccountId = _accountId,
                NetworkId = _networkId
            });
            OnSelected?.Invoke();
        }

        private async void Close(object sender, RoutedEventArgs e)
        {
            var wNetwork = Networks.GetNetwork(_networkId);
            await wNetwork.RemoveAccount(_accountId);
            OnRemove?.Invoke();
        }
    }
}
