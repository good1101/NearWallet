using NearWallet.Controls.Ext;

namespace NearWallet.Controls.Wallet
{
    /// <summary>
    /// Логика взаимодействия для PageWallet.xaml
    /// </summary>
    public partial class PageWallet : PageControl
    {
        public static Navigation Navigation { get; private set; }

        public PageWallet()
        {
            InitializeComponent();
        }

        public override void Visible()
        {
            if (Navigation == null)
            {
                var pageInfo = new PageWalletInfo();
                Navigation = new Navigation(a => 
                transit.Content = a, pageInfo);
                Navigation.SetStartPage();
            }
            else
            {
                Navigation.UpdateCurrentPage();
            }
        }
    }
}
