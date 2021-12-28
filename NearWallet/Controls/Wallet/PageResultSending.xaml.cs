using NearWallet.Entities.Network;
using NearWallet.Entities.Wallet;
using NearWallet.Utilites;
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

namespace NearWallet.Controls.Wallet
{
    /// <summary>
    /// Логика взаимодействия для PageResultSending.xaml
    /// </summary>
    public partial class PageResultSending : UserControl
    {
        public PageResultSending(SendInfo sendInfo)
        {
            InitializeComponent();
            _sendInfo = sendInfo;
        }
        SendInfo _sendInfo;

        private void Bt_continue_Click(object sender, RoutedEventArgs e)
        {
            PageWallet.Navigation.SetStartPage();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!IsVisible)
                return;
            rn_amount.Text = _sendInfo.NearFormatAmount;
            rn_price.Text = _sendInfo.USDAmount;
            rn_toId.Text = _sendInfo.ToAccountId;
        }

        private void Bt_continue_Click_1(object sender, RoutedEventArgs e)
        {
            PageWallet.Navigation.SetStartPage();
        }

        private void Bt_view_Click(object sender, RoutedEventArgs e)
        {
            var url = Networks.GetCurrentNetwork().TransactionExplorerUrl + _sendInfo.TransactionId;
            WebInfo.OpenUrl(url);
        }
    }
}
