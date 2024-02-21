using NearClient.Utilities;
using NearWallet.Entities.Network;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Routing;

namespace NearWallet.Utilites
{
    class WebInfo
    {
        static string URL_PRICE_NEAR = "/fiat";

        public static async Task<double> GetPriceNear()
        {
            try
            {
                WalletNetwork walletNetwork = Networks.GetCurrentNetwork();
                dynamic jResponse = await Web.GetJson(walletNetwork.HelperUrl + URL_PRICE_NEAR);
                double usd = jResponse.near.usd;
                return usd;
            }
            catch(Exception)
            {
                Messages.AddMessage("Error", "Failed to get the cost.");
                return double.NaN;
            }
        }

        public static async Task<dynamic> GetActivity(string accountId)
        {
            try
            {
                WalletNetwork walletNetwork = Networks.GetCurrentNetwork();
                var response = await Web.GetJson($"{walletNetwork.HelperUrl}/account/{accountId}/activity");
                return response;
            }
            catch(Exception e)
            {
                Messages.AddError(e);
                return null;
            }
        }

        public  static async Task<dynamic> GetStakingInfo(string accountId)
        {
            try
            {
                WalletNetwork walletNetwork = Networks.GetCurrentNetwork();
                var response = await Web.GetJson($"{walletNetwork.HelperUrl}/staking-deposits/{accountId}");
                return response;
            }
            catch(Exception e)
            {
                Messages.AddError(e);
                return null;
            }
        }

        public static async Task<UInt128> GetBalansStaking(string accountId)
        {
            var stakingInfo = await GetStakingInfo(accountId);
            if (stakingInfo == null)
                return 0;
            UInt128 balans = 0;
            foreach (var bl in stakingInfo)
            {
                string deposit = bl.deposit;
                if (deposit[0] == '-')
                    continue;
                balans += UInt128.Parse(deposit);
            }
            return balans;
        }

        public static void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch(Exception e)
            {
                MainWindow.AddMessage("Error", e.Message);
            }
        }
    }
}
