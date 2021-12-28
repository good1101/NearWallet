using NearWallet.Controls.Ext;
using NearWallet.Controls.Wallet;
using NearWallet.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NearWallet.Controls
{
    /// <summary>
    /// Логика взаимодействия для PageHome.xaml
    /// </summary>
    public partial class PageHome : PageControl
    {
        public PageHome()
        {
            InitializeComponent();
            Init();
        }
        public static Navigation Navigation { get; private set; }
        List<UserControl> _controls = new List<UserControl>();

        void Init()
        {
            PageWallet pageWallet = new PageWallet();
            _controls.Add(pageWallet);
            Navigation = new Navigation((a) => transit.Content = a, pageWallet);
            Navigation.SetStartPage();

            foreach(ToggleButton toggle in st_tab.Children.OfType<ToggleButton>())
            {
                toggle.Checked += Toggle_Checked;
                toggle.Unchecked += Toggle_Unchecked;
            }
        }

        public override void Visible()
        {
            Navigation.UpdateCurrentPage();
        }

        private void Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
           
        }

        private void Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ToggleButton toggle = sender as ToggleButton;
            toggle.IsEnabled = false;
            Type t = toggle.Tag as Type;
            var control = _controls.Where(a => a.GetType() == t).FirstOrDefault();
            if (control == null)
            {
                control = Activator.CreateInstance(t, false) as UserControl;
                _controls.Add(control);
            }
            Navigation.SetPage(control);
            foreach (ToggleButton tog in st_tab.Children.OfType<ToggleButton>())
            {
                if (tog != toggle)
                {
                    tog.IsChecked = false;
                    tog.IsEnabled = true;
                }
            }
        }
    }
}
