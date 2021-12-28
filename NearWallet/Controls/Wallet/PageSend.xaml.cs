using NearClient;
using NearClient.Utilities;
using NearWallet.Controls.Ext;
using NearWallet.Entities;
using NearWallet.Entities.Network;
using NearWallet.Entities.Wallet;
using NearWallet.Utilites;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace NearWallet.Controls.Wallet
{
    /// <summary>
    /// Логика взаимодействия для PageSend.xaml
    /// </summary>
    public partial class PageSend : PageControl
    {
        public PageSend()
        {
            InitializeComponent();
        }
        private double _amountSend;
        private double _price;
        private const int INTERVAL_REQUEST = 1000;
        private string _inputId;
        DispatcherTimer _timer;
        private UInt128 _balans;
        private bool _isCheckID;
        private string _usdBalans;

        public async override void Visible()
        {
            using (var initialize = new Initialize(this))
            {
                WalletNetwork walletNetwork = Networks.GetCurrentNetwork();
                AccountState state = await walletNetwork.GetAccountState(Networks.CurrentAccountId);
                _balans = UInt128.Parse(state.Amount);
                lb_balans.Content = Utility.FormatNearString(state.Amount) + " NEAR";
                _price = await WebInfo.GetPriceNear();
            }
        }


        private void Tb_amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsVisible)
                return;
            TextBox textBox = sender as TextBox;
            double curValue = 0;
            string input = textBox.Text.Replace(',', '.');
            if (double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out curValue))
                _amountSend = curValue;
            else
                _amountSend = 0;

            if (_amountSend > 0)
            {
                UInt128 nearSend = Utility.GetNearFormat(_amountSend);
                if (nearSend <= _balans)
                    textBox.Foreground = Brushes.Black;
                else
                    textBox.Foreground = Brushes.Gray;
            }
            else
                textBox.Foreground = Brushes.Gray;
            double usdBalans = Math.Round(_price * _amountSend, 2);
            _usdBalans = $"≈ {usdBalans} USD";
            lb_usd.Content = _usdBalans;
            ChecData();
        }
        
        private void Bt_back_Click(object sender, RoutedEventArgs e)
        {
            PageWallet.Navigation.Back();
        }

        private void Tb_accountID_TextChanged(object sender, TextChangedEventArgs e)
        {
            _isCheckID = false;
            tb_accountID.Foreground = Brushes.Gray;
            _inputId = (sender as TextBox).Text;
            if (_timer == null)
            {
                _timer = new DispatcherTimer();
                _timer.Tick += _timer_Tick;
            }
            if (!_timer.IsEnabled)
            {
                _timer.Interval = TimeSpan.FromMilliseconds(INTERVAL_REQUEST);
                _timer.Start();
            }
        }

        private async void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            await CheckAccountID(_inputId);
            ChecData();

        }

        async Task CheckAccountID(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || id.Length < 2)
                return;
            WalletNetwork walletNetwork = Networks.GetCurrentNetwork();
            if (!await walletNetwork.ExitsAccountId(id))
                return;
            tb_accountID.Foreground = Brushes.Black;
            _isCheckID = true;
        }

        double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
        {
            return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
        }
        void ChecData()
        {
            UInt128 ner = Utility.GetNearFormat(_amountSend);
            if (_balans >= ner && ner != 0 && _isCheckID)
            {
                
                bt_send.IsEnabled = true;
            }
            else
            {
                bt_send.IsEnabled = false;
            }
        }

        private void Bt_send_Click(object sender, RoutedEventArgs e)
        {
            SendInfo sendInfo = new SendInfo()
            {
                NearAmount = Utilites.Utility.GetNearFormat(_amountSend),
                USDAmount = _usdBalans,
                FromAccountId = Networks.CurrentAccountId,
                ToAccountId = _inputId
            };
            PageWaitSend pageWaitSend = new PageWaitSend(sendInfo);
            PageWallet.Navigation.SetPage(pageWaitSend);
        }


    }
}
