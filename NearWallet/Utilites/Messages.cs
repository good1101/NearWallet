using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearWallet.Utilites
{
    class Messages
    {
        static Action<string, string> _userView = MainWindow.AddMessage;

        public static void AddError(Exception e)
        {
            _userView("Error", e.Message);
        }
        public static void AddMessage(string header, string message)
        {
            _userView(header, message);
        }
    }
}
