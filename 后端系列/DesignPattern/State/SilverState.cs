using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    /// <summary>
    /// 具体状态类，新开账户
    /// </summary>
    public class SilverState : State
    {
        public SilverState(State state) : this(state.Balance, state.Account)
        {
        }

        public SilverState(decimal balance, Account account)
        {
            Balance = balance;
            Account = account;
            Interest = 0.0M;
            LowerLimit = 0.0M;
            UpperLimit = 100.0M;
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
