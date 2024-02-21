using NearClient;
using NearWallet.Controls.Ext;
using NearWallet.Entities;
using NearWallet.Entities.Network;
using NearWallet.Utilites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

namespace NearWallet.Controls.Wallet
{
    /// <summary>
    /// Логика взаимодействия для PageWalletInfo.xaml
    /// </summary>
    public partial class PageWalletInfo : PageControl
    {
        public PageWalletInfo()
        {
            InitializeComponent();
        }

        public override void Visible()
        {
            Update();
        }


        async void Update()
        {
            using (var initialize = new Initialize(this))
            {
                WalletNetwork walletNetwork = Networks.GetCurrentNetwork();
                AccountState state;
                state = await walletNetwork.GetAccountState(Networks.CurrentAccountId);
                if (state == null) return;
                string amount = Utility.FormatNearString(state.Amount);
                lb_balasNear.Content = amount + " NEAR";
                lb_accountId.Content = Networks.CurrentAccountId;
                double numAmount = double.Parse(amount, CultureInfo.InvariantCulture);
                double price = await WebInfo.GetPriceNear();
                if (!double.IsNaN(price))
                {
                    lb_Price.Content = "$" + price;
                    double usdBalans = Math.Round(price * numAmount, 2);
                    lb_smallBalansUsd.Content = "≈ $" + usdBalans;
                    lb_balansUsd.Content = "$" + usdBalans;
                }
            }
        }



        private void BtSend_Click(object sender, RoutedEventArgs e)
        {
            PageWallet.Navigation.SetPage(new PageSend());
        }


    }
}
