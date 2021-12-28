using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearWallet.Entities.Network
{
    class NetworkConfig
    {
        public string NetworkID { get; set; }
        public string NodeUrl { get; set; }

        public override string ToString()
        {
            return NetworkID;
        }
    }
}
