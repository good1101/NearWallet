using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearWallet.Utilites.Exceptions
{
    class WalletException : Exception
    {
        public WalletException() { }
        public WalletException(string message) : base(message)
        {

        }
    }
}
