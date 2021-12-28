using NearClient;
using NearWallet.Entities;
using NearWallet.Entities.Activity;
using NearWallet.Entities.Network;
using NearWallet.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NearWallet.Controls.Activity
{
    /// <summary>
    /// Логика взаимодействия для ActionControl.xaml
    /// </summary>
    public partial class ActionControl : UserControl
    {
        public ActionControl()
        {
            InitializeComponent();
        }

        public ActionControl(ActionInfo actionInfo)
        {
            InitializeComponent();
            _actionInfo = actionInfo;
            SetInfo();
        }

        private ActionInfo _actionInfo;

        private void SetInfo()
        {
            rec_icon.Style = GetIcon(_actionInfo.ActionType);
            SetAmountInfo();
            tb_firstInfo.Text = GetFirstInfo();
            tb_lastInfo.Text = GetLastInfo();
            if (string.IsNullOrWhiteSpace(tb_lastInfo.Text))
                tb_lastInfo.Visibility = Visibility.Collapsed;
            lb_time.Content = TimeFormat.GetViewTime(_actionInfo.DateTime);

        }

        private void SetAmountInfo()
        {
            if (_actionInfo.Amount == null || _actionInfo.ActionType == ActionType.FunctionCall ||
                _actionInfo.ActionType == ActionType.Stake ||
                _actionInfo.ActionType == ActionType.CreateAccount)
            {
                lb_amount.Visibility = Visibility.Collapsed;
                return;
            }
            string amount = "";
            if(_actionInfo.SignerId == Networks.CurrentAccountId)
            {
                amount = "-";
                var bc = new BrushConverter();
                lb_amount.Foreground = (Brush)bc.ConvertFrom("#FF595959");
            }
            else
            {
                amount = "+";
                var bc = new BrushConverter();
                lb_amount.Foreground = (Brush)bc.ConvertFrom("#FF06DA06");
            }
            amount += $"{ Utility.FormatNearString(_actionInfo.Amount)} NEAR";
            lb_amount.Content = amount;
        }

        private string GetLastInfo()
        {
            switch (_actionInfo.ActionType)
            {
                case ActionType.Transfer:
                    if (Networks.CurrentAccountId == _actionInfo.SignerId)
                        return $"to {_actionInfo.ReceiverId}";
                    else
                        return $"from {_actionInfo.SignerId}";
                case ActionType.FunctionCall:
                    return $"{_actionInfo.MethodName} in {_actionInfo.ReceiverId}";
                case ActionType.AddKey:
                    return $"for {_actionInfo.ReceiverId}";
                case ActionType.CreateAccount:
                    return _actionInfo.ReceiverId;
            }
            return "";
        }
        private string GetFirstInfo()
        {
            switch (_actionInfo.ActionType)
            {
                case ActionType.Transfer:
                    if (Networks.CurrentAccountId == _actionInfo.SignerId)
                        return "Sent Near";
                    else
                        return "Received NEAR";
                case ActionType.FunctionCall:
                    return "Method called";
                case ActionType.Stake:
                    return "Staked";
                case ActionType.AddKey:
                    return "Access Key added";
                case ActionType.CreateAccount:
                    return "New account created";
                case ActionType.DeleteKey:
                    return "Key deleted";
            }
            return "";
        }

        public Style GetIcon(ActionType actionType)
        {
            switch(actionType)
            {
                case ActionType.Transfer: return GetResources("rectSendIcon") as Style;
                case ActionType.Stake: return  GetResources("sendIcon") as Style;
                case ActionType.FunctionCall: return GetResources("rectMethodIcon") as Style;
                case ActionType.AddKey: return GetResources("rectKey") as Style;
                case ActionType.CreateAccount: return GetResources("rectAccount") as Style;
                case ActionType.DeleteKey: return GetResources("rectKeyDel") as Style;
               
                default: throw new NotImplementedException(actionType.ToString());
            }
        }

        object GetResources(string key)
        {
            return Application.Current.TryFindResource(key);
        }

        private void UserControl_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string url = Networks.GetCurrentNetwork().TransactionExplorerUrl + _actionInfo.Hash;
            WebInfo.OpenUrl(url);
        }
    }
}
