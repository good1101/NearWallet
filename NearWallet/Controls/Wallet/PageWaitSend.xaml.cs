using NearWallet.Entities.Network;
using NearWallet.Entities.Wallet;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для PageWaitSend.xaml
    /// </summary>
    public partial class PageWaitSend : UserControl
    {
        public PageWaitSend(SendInfo info)
        {
            InitializeComponent();
            _sendInfo = info;
        }


        SendInfo _sendInfo;

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!IsVisible)
                return;

            lb_nearAmount.Content = _sendInfo.NearFormatAmount + " NEAR"; ;
            lb_price.Content = _sendInfo.USDAmount;
            lb_from.Content = _sendInfo.FromAccountId;
            lb_to.Content = _sendInfo.ToAccountId;
            
        }

        private void Bt_back_Click(object sender, RoutedEventArgs e)
        {
            PageWallet.Navigation.Back();
        }

        private async void Bt_send_Click(object sender, RoutedEventArgs e)
        {
            WalletNetwork walletNetwork = Networks.GetCurrentNetwork();
            pb.Visibility = Visibility.Visible;
            bt_send.IsEnabled = false;
            var res = await walletNetwork.Send(_sendInfo.ToAccountId, _sendInfo.NearAmount);
            _sendInfo.TransactionId = res.Transaction.Id;
            PageResultSending pageResultSending = new PageResultSending(_sendInfo);
            PageWallet.Navigation.SetPage(pageResultSending);
        }
    }
}
