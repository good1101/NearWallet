using NearClient;
using NearWallet.Utilites.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearWallet.Entities.Activity
{
    public class ActionInfo
    {
        public ActionInfo(dynamic action)
        {
            ParseAction(action);
        }

        public ActionType ActionType { get; private set; }
        public string Amount { get; private set; }
        public DateTime DateTime { get; private set; }
        public string SignerId { get; private set; }
        public string ReceiverId { get; private set; }
        public string BlockHash { get; private set; }
        public string Hash { get; private set; }
        public string MethodName { get; private set; }
        public string PublickKey { get; private set; }

        private void ParseAction(dynamic action)
        {
            ActionType = ActionInfo.ParseNameAction(action.action_kind.ToString());
            SignerId = action.signer_id;
            ReceiverId = action.receiver_id;
            long u = action.block_timestamp / 100;
            DateTime = new DateTime(1970, 1, 1).AddTicks(u);
            BlockHash = action.block_hash;
            Hash = action.hash;
            switch (ActionType)
            {
                case ActionType.Transfer: ParseTransfer(action); break;
                case ActionType.FunctionCall: ParseFunctionCall(action); break;
                case ActionType.Stake: ParseStake(action); break;
                case ActionType.AddKey: ParseAddKey(action); break;
                case ActionType.CreateAccount: break;
                case ActionType.DeleteKey: break;
                
                default: throw new NotImplementedException(ActionType.ToString());
            }
        }

        private void ParseAddKey(dynamic action)
        {
            PublickKey = action.args.public_key;
        }
        private void ParseFunctionCall(dynamic action)
        {
            Amount = action.args.deposit;
            MethodName = action.args.method_name;
        }

        private  void ParseTransfer(dynamic action)
        {
            Amount = action.args.deposit;
        }
        private void ParseStake(dynamic action)
        {
            Amount = action.args.stake;
        }

        public static ActionType ParseNameAction(string name)
        {
            switch(name)
            {
                case "TRANSFER": return ActionType.Transfer;
                case "STAKE": return ActionType.Stake;
                case "FUNCTION_CALL": return ActionType.FunctionCall;
                case "ADD_KEY": return ActionType.AddKey;
                case "CREATE_ACCOUNT": return ActionType.CreateAccount;
                case "DELETE_KEY": return ActionType.DeleteKey;

                default: throw new ParseException(name + " not found!");

            }
        }
    }
}
