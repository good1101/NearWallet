using MahApps.Metro.Controls.Dialogs;
using NearWallet.Entities.Network;
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

namespace NearWallet.Controls.Accounts
{
    /// <summary>
    /// Логика взаимодействия для KeyView.xaml
    /// </summary>
    public partial class KeyView : UserControl
    {
        public KeyView(string permission, string key)
        {
            InitializeComponent();
            _permission = permission;
            _key = key;
            Init();
        }

        string _permission;
        string _key;
        public Action ActionDelete { get; set; }

        async void Init()
        {
            string publickKey = await Networks.GetCurrentNetwork().GetPublickKey();
            if (publickKey == _key)
                bt_del.Visibility = Visibility.Hidden;
            tb_permission.Text = _permission;
            tb_key.Text = _key;
        }
        

        private async void Bt_del_Click(object sender, RoutedEventArgs e)
        {
            var result = await MainWindow.Alert("Confirm key deletion.", MessageDialogStyle.AffirmativeAndNegative);
            if (result == MessageDialogResult.Negative)
                return;
            var resultDel = await Networks.GetCurrentNetwork().DeleteKey(_key);
            if(resultDel.Status?.Failure?.ErrorType != null)
            {
                Messages.AddMessage("Error", resultDel.Status.Failure.ErrorMessage);
                return;
            }
            ActionDelete?.Invoke();
            Messages.AddMessage("Info", "The key has been removed.");
            Rectangle r = new Rectangle();
            r.Fill = new SolidColorBrush();
        }
    }
}
