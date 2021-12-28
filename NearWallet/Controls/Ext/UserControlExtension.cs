using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NearWallet.Controls.Ext
{
    static class UserControlExtension 
    {
        public static void Wait(this UserControl userControl)
        {
            Grid grid = userControl.Content as Grid;
            if (grid == null)
                return;
            grid.Children.Add(new PageWait());
        }
        public static void EndWait(this UserControl userControl)
        {
            Grid grid = userControl.Content as Grid;
            if (grid == null)
                return;
            var pageWait = grid.Children.OfType<PageWait>().FirstOrDefault();
            if (pageWait == null)
                return;
            grid.Children.Remove(pageWait);
        }

 
    }
}
