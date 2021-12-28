using NearClient.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearWallet.Entities.Wallet
{
    public class SendInfo
    {
        public string FromAccountId { get; set; }
        public string ToAccountId { get; set; }
        public UInt128 NearAmount { get; set; }
        public string USDAmount { get; set; }
        public string TransactionId { get; set; }

        public string NearFormatAmount {
            get
            {
                return Utilites.Utility.FormatNearString(NearAmount);
            }
        }
    }
}
