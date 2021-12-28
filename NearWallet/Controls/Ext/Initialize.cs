using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NearWallet.Controls.Ext
{
    class Initialize : IDisposable
    {
        UserControl _userControl;

        public Initialize(UserControl userControl)
        {
            _userControl = userControl;
            _userControl.Wait();
        }

        public void Dispose()
        {
            _userControl.EndWait();
        }
    }
}
