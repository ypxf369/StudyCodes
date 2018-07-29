using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    /// <summary>
    /// 具体状态类，标准账户
    /// </summary>
    public class GoldState : State
    {
        public GoldState(State state)
        {
            Balance = state.Balance;
            Account = state.Account;
            Interest = 0.05M;
            LowerLimit = 1000.00M;
            UpperLimit = 1000000.00M;
        }
        public override void Deposit(decimal amount)
        {
            this.Balance += amount;
            this.ChangeState();
        }

        public override void PayInterest()
        {
            Balance += Balance * Interest;
        }

        public override void Withdraw(decimal amount)
        {
            Balance -= amount;
            this.ChangeState();
        }
    }
}
