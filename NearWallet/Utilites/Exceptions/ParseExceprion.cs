using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearWallet.Utilites.Exceptions
{
    class ParseException : WalletException
    {
        public ParseException(string message) : base(message) { }
        public ParseException() { }

    }
}
