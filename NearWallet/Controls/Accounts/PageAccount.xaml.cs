using NearClient;
using NearWallet.Controls.Ext;
using NearWallet.Entities.Network;
using NearWallet.Utilites;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace NearWallet.Controls.Accounts
{
    /// <summary>
    /// Логика взаимодействия для PageAccount.xaml
    /// </summary>
    public partial class PageAccount : PageControl
    {
        public PageAccount()
        {
            InitializeComponent();

        }

        public async override void Visible()
        {
            using (var inint = new Initialize(this))
            {
                tb_idAccount.Text = Networks.CurrentAccountId;
                WalletNetwork walletNetwork = Networks.GetCurrentNetwork();
                AccountState state = await walletNetwork.GetAccountState(Networks.CurrentAccountId);
                if (state == null)
                    return;
                string amount = Utility.FormatNearString(state.Amount);
                lb_balansNear.Content = amount + " NEAR";
                double numAmount = double.Parse(amount, CultureInfo.InvariantCulture);
                double price = await WebInfo.GetPriceNear();
                double usdBalans = Math.Round(price * numAmount, 2);
                lb_smallBalansUsd.Content = "≈ $" + usdBalans;
                var stakingBalans = await WebInfo.GetBalansStaking(Networks.CurrentAccountId);
                double dBalans = Utility.FormatNearDouble(stakingBalans);
                lb_stakingNear.Content = dBalans + " NEAR";
                double usdStakingBalans = Math.Round(price * dBalans, 2);
                lb_stakingSmallBalansUSD.Content = "≈ $" + usdStakingBalans;
                await SetKeys();
            }
        }

        async Task SetKeys()
        {
            WalletNetwork walletNetwork = Networks.GetCurrentNetwork();
            var result = await walletNetwork.GetKeys();
            if (result == null)
                return;
            KeyView[] keyViews = sp_content.Children.OfType<KeyView>().ToArray();
            foreach(var kv in keyViews)
            {
                sp_content.Children.Remove(kv);
            }

            foreach(var key in result.keys)
            {
                string publicKey = key.public_key;
                string peremission = string.Empty;
                try
                {
                    peremission = key.access_key.permission.FunctionCall.receiver_id;
                }
                catch
                {
                    peremission = key.access_key.permission;
                }
                KeyView keyView = new KeyView(peremission, publicKey);
                keyView.ActionDelete = () => sp_content.Children.Remove(keyView);
                sp_content.Children.Add(keyView);
            }
        }

        private void Copy_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(tb_idAccount.Text);
            Storyboard storyboard = FindResource("aminateCopy") as Storyboard;
            gr_copy.BeginStoryboard(storyboard);
        }
    }
}
