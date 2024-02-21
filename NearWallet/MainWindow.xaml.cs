using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using NearWallet.Controls;
using NearWallet.Controls.Accounts;
using NearWallet.Controls.Ext;
using NearWallet.Controls.Settings;
using NearWallet.Entities.Network;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace NearWallet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private static MainWindow _mainWindow;
        public static Navigation Navigation { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Navigation = new Navigation(a => transitioningControl.Content = a);
            _mainWindow = this;
        }

        private void Bt_Setting(object sender, RoutedEventArgs e)
        {
            settingsFlyout.IsOpen = !settingsFlyout.IsOpen;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                if (Networks.IsAccounts())
                    Navigation.SetPage(new PageHome());
                else
                    Navigation.SetPage(new PageAddAccount() { Width = double.NaN, Height = double.NaN });
            }
        }

        private void AddNetwork(object sender, RoutedEventArgs e)
        {
            settingsFlyout.IsOpen = false;
            Navigation.SetPage(new PageAddNetwork());

        }

        public static async Task<MessageDialogResult> Alert(string message, MessageDialogStyle messageDialogStyle = MessageDialogStyle.Affirmative)
        {
           return await _mainWindow.ShowMessageAsync("Message", message, messageDialogStyle);
        }

        private void AddAccount(object sender, RoutedEventArgs e)
        {
            settingsFlyout.IsOpen = false;
            Navigation.SetPage(new PageAddAccount());
        }

        private void SelectAccount(object sender, RoutedEventArgs e)
        {
            settingsFlyout.IsOpen = false;
            Navigation.SetPage(new PageSelectAccount());

        }
        public static void AddMessage(string header, string message)
        {
            var messageView = new MessageView(header, message);
            messageView.EndView = () => _mainWindow.grid.Children.Remove(messageView);
            _mainWindow.grid.Children.Add(messageView);
        }

        private void CreateAccount(object sender, RoutedEventArgs e)
        {
            settingsFlyout.IsOpen = false;
            Navigation.SetPage(new PageCreateAccount());
        }
    }
}
