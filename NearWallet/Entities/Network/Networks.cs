using NearWallet.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearWallet.Entities.Network
{
    class Networks
    {
        const string CONFIG_NETWORKS_NAME = "networkConfigs";
        const string CONFIG_CURRENT_NAME = "walletConfigs";
        private static Dictionary<string, NetworkConfig> _networkConfigs;
        public static Dictionary<string, NetworkConfig> NetworkConfigs
        {
            get {
                if (_networkConfigs == null)
                    _networkConfigs = FileConfig.Load<Dictionary<string, NetworkConfig>>(CONFIG_NETWORKS_NAME);
                return _networkConfigs;
            }
        }

        private static Dictionary<string, WalletNetwork> _networks = new Dictionary<string, WalletNetwork>();
        private static CurrentWallet _currentWallet;
        private static CurrentWallet CurrentWallet
        {
            get
            {
                if (_currentWallet == null)
                    _currentWallet = FileConfig.Load<CurrentWallet>(CONFIG_CURRENT_NAME);
                    return _currentWallet;
            }
        }

        internal static void SetCurrent(CurrentWallet currentWallet)
        {
            _currentWallet = currentWallet;
            FileConfig.Save(CONFIG_CURRENT_NAME, _currentWallet);
        }

        public static string CurrentAccountId => CurrentWallet?.AccountId;
        public static string CurrentNetworkId => CurrentWallet?.NetworkId;



        public static bool IsAccounts()
        {
            return CurrentAccountId != null;
        }

        public static WalletNetwork GetNetwork(string networkID)
        {
            if (_networks.ContainsKey(networkID))
                return _networks[networkID];
            if (NetworkConfigs.ContainsKey(networkID))
            {
                NetworkConfig config = NetworkConfigs[networkID];
                _networks[networkID] = new WalletNetwork(config.NetworkID, config.NodeUrl);
                return _networks[networkID];
            }
            return null;
        }

        public static WalletNetwork GetCurrentNetwork()
        {
            if (CurrentNetworkId == null)
                return null;
           return GetNetwork(CurrentNetworkId);
        }

        public static void AddNetwork(NetworkConfig config)
        {
            if(NetworkConfigs.ContainsKey(config.NetworkID))
            {
                throw new Exception("This network has already been added.");
            }
            NetworkConfigs.Add(config.NetworkID, config);
            FileConfig.Save(CONFIG_NETWORKS_NAME, _networkConfigs);
        }
    }
}
