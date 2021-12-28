using NearWallet.Controls.Ext;
using NearWallet.Entities.Activity;
using NearWallet.Entities.Network;
using NearWallet.Utilites;
using System.Windows;
using System.Windows.Controls;

namespace NearWallet.Controls.Activity
{
    /// <summary>
    /// Логика взаимодействия для PageActivity.xaml
    /// </summary>
    public partial class PageActivity : PageControl
    {
        public PageActivity()
        {
            InitializeComponent();
        }

        public override void Visible()
        {
            Update();
        }

        private async void Update()
        {
            using (var initialize = new Initialize(this))
            {
                var activity = await WebInfo.GetActivity(Networks.CurrentAccountId);
                if (activity == null)
                    return;
                Init(activity);
            }
        }

        private void Init(dynamic activity)
        {
            Button button = sp_actions.Children[sp_actions.Children.Count - 1] as Button;
            sp_actions.Children.Clear();
            sp_actions.Children.Add(button);
            foreach(var action in activity)
            {
                ActionInfo actionInfo = new ActionInfo(action);
                sp_actions.Children.Insert(sp_actions.Children.Count - 1, new ActionControl(actionInfo));
            }
            scroll.ScrollToVerticalOffset(0);
        }

        private void Bt_allList_Click(object sender, RoutedEventArgs e)
        {
            var url = Networks.GetCurrentNetwork().ExplorerUrl + Networks.CurrentAccountId;
            WebInfo.OpenUrl(url);
        }
    }
}
