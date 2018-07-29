using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    /// <summary>
    /// 具体状态类，透支账户
    /// </summary>
    public class RedState : State
    {
        public RedState(State state)
        {
            Balance = state.Balance;
            Account = state.Account;
            Interest = 0.00M;
            LowerLimit = -100.00M;
            UpperLimit = 0.00M;
        }
        public override void Deposit(decimal amount)
        {
            this.Balance += amount;
            this.ChangeState();
        }

        public override void PayInterest()
        {
            //没有利息
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine("没有钱可以取了。");
            this.ChangeState();
        }
    }
}
