using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NearClient;
using NearClient.KeyStores;
using NearClient.Utilities;
using NearClient.Providers;
using System.Web;
using NearWallet.Utilites;

namespace NearWallet.Entities.Network
{
    class WalletNetwork
    {
        private readonly string _networkId;
        private readonly string _nodeUrl;
        private readonly Near _near;
        public string HelperUrl { get; private set; }
        const string KEY_DIR = "data";
        public string ExplorerUrl { get; private set; }
        public string TransactionExplorerUrl { get; private set; }
        readonly KeyStore _keyStore = new UnencryptedFileSystemKeyStore(KEY_DIR);


        public WalletNetwork(string networkId, string nodeUrl)
        {
            _nodeUrl = nodeUrl;
            _networkId = networkId;
            HelperUrl = _nodeUrl.Replace("rpc", "helper");
            ExplorerUrl = _nodeUrl.Replace("rpc", "explorer") + "/accounts/";
            TransactionExplorerUrl = _nodeUrl.Replace("rpc", "explorer") + "/transactions/";
            _near = new Near(config: new NearConfig()
            {
                NetworkId = _networkId,
                NodeUrl = nodeUrl,
                ProviderType = ProviderType.JsonRpc,
                SignerType = SignerType.InMemory,
                KeyStore = _keyStore,
                WebProxy = new System.Net.WebProxy("127.0.0.1:8888")
            });
        }

        public async Task<string[]> GetAccounts()
        {
           return await _keyStore.GetAccountsAsync(_networkId);
        }

        public async Task AddAccount(string accountId, string privateKey)
        {
            try
            {
                KeyPair keyPair = KeyPair.FromString(privateKey);
                await _keyStore.SetKeyAsync(_networkId, accountId, keyPair);
            }
            catch(Exception e)
            {
                Messages.AddError(e);
            }
        }

        public async Task RemoveAccount(string accountId)
        {
            await _keyStore.RemoveKeyAsync(_networkId, accountId);
        }

        public async Task<AccountState> GetAccountStateId(string accountId)
        {
            try
            {
                Account account = new Account(_near.Connection, accountId);
                AccountState state = await account.GetStateAsync();
                return state;
            }
            catch(Exception e)
            {
                Messages.AddError(e);
                return null;
            }
        }
        public async Task<AccountState> GetAccountState(string accountId)
        {
            try
            {
                Account account = await _near.AccountAsync(accountId.ToLower());
                AccountState state = await account.GetStateAsync();
                return state;
            }
            catch(Exception e)
            {
                Messages.AddError(e);
                return null;
            }
        }

        public async Task<string> GetPublicKey()
        {
            try
            {
                KeyPair key = await _keyStore.GetKeyAsync(_networkId, Networks.CurrentAccountId);
                PublicKey publicKey = key.GetPublicKey();
                return publicKey.ToString();
            }
            catch
            {
                Messages.AddMessage("Error", "No key.");
                return null;
            }
        }

        public async Task<dynamic> GetKeys()
        {
            try
            {
                Account account = await _near.AccountAsync(Networks.CurrentAccountId);
                var keys = await account.GetAccessKeysAsync();
                return keys;
            }
            catch
            {
                Messages.AddMessage("Error", "Failed to get keys.");
                return null;
            }
        }

        public async Task<FinalExecutionOutcome> DeleteKey(string publicKey)
        {
            try
            {
                Account account = await _near.AccountAsync(Networks.CurrentAccountId);
                return await account.DeleteKeyAsync(publicKey);
            }
            catch
            {
                Messages.AddMessage("Error", "Failed to delete key.");
                return null;
            }
        }
        public async Task<bool> ExitsAccountId(string accountId)
        {
            try
            {
                await _near.AccountAsync(accountId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<FinalExecutionOutcome> Send(string id, UInt128 amount)
        {
            try
            {
                Account account = await _near.AccountAsync(Networks.CurrentAccountId);
                FinalExecutionOutcome final = await account.SendMoneyAsync(id, amount);
                return final;
            }
            catch(Exception e)
            {
                Messages.AddError(e);
                return null;
            }
        }
        public async Task<FinalExecutionOutcome> CreateAccount(string accountId, UInt128 amount)
        {
            try
            {
                Account account = await _near.AccountAsync(Networks.CurrentAccountId);
                KeyPair privateKey = KeyPairEd25519.FromRandom64();
                await AddAccount(accountId, privateKey.ToString());
                PublicKey publicKey = privateKey.GetPublicKey();
                var final = await account.CreateAccountAsync(accountId, publicKey, amount);
                 return final;
            }
            catch(Exception e)
            {
                Messages.AddError(e);
                return null;
            }


        }
    }
}
