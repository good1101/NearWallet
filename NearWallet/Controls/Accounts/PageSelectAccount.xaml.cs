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
    /// Логика взаимодействия для PageSelectAccount.xaml
    /// </summary>
    public partial class PageSelectAccount : PageControl
    {
        public PageSelectAccount()
        {
            InitializeComponent();
            IsNavigate = true;
            Init();
        }

        async void Init()
        {
            foreach (var net in Networks.NetworkConfigs)
            {
                WalletNetwork walletNetwork = Networks.GetNetwork(net.Key);
                string[] accounts = await walletNetwork.GetAccounts();
                foreach(var accountId  in accounts)
                {
                    var view = new AccountView(accountId, net.Key);
                    view.OnSelected = () => Back();
                    view.OnRemove = () => Init();
                    panel.Children.Add(view);

                }
            }
        }
    }
}
