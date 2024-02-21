using NearClient;
using NearClient.Utilities;
using NearWallet.Controls.Ext;
using NearWallet.Entities.Network;
using NearWallet.Utilites;
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
using System.Windows.Threading;

namespace NearWallet.Controls.Accounts
{
    /// <summary>
    /// Логика взаимодействия для PageCreateAccount.xaml
    /// </summary>
    public partial class PageCreateAccount : PageControl
    {
        public PageCreateAccount()
        {
            InitializeComponent();
            IsNavigate = true;
        }
        private double _amountSend;
        private double _price;
        private string _inputId;
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
                tb_accountID.Text = $".{Networks.CurrentAccountId}";
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
            Back();
        }

        private void Tb_accountID_TextChanged(object sender, TextChangedEventArgs e)
        {
            _isCheckID = false;
            tb_accountID.Foreground = Brushes.Gray;
            _inputId = (sender as TextBox).Text;
            CheckAccountID(_inputId);
        }

        void CheckAccountID(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || id.Length < 2)
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

        private async void Bt_send_Click(object sender, RoutedEventArgs e)
        {
            bt_send.IsEnabled = false;
            WalletNetwork walletNetwork = Networks.GetCurrentNetwork();
            var result = await walletNetwork.CreateAccount(_inputId, Utility.GetNearFormat(_amountSend));
            if (result == null)
                await MainWindow.Alert("Failed...");
            else
                await MainWindow.Alert($"Account {_inputId} created!");
        }
    }
}
