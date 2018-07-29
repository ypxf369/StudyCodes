using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    /// <summary>
    /// 维护当前账户的状态
    /// </summary>
    public class Account
    {
        public State state;
        public string owner;

        public Account(string owner)
        {
            this.state = new SilverState(0.00M, this);
            this.owner = owner;
        }
        public decimal Balance => state.Balance;

        //存钱
        public void Deposit(decimal amount)
        {
            state.Deposit(amount);
            Console.WriteLine("存款金额为 {0:C}——", amount);
            Console.WriteLine("账户余额为 {0:C}", Balance);
            Console.WriteLine("账户状态为 {0}", state.GetType().Name);
            Console.WriteLine();
        }

        //取钱
        public void Withdraw(decimal amount)
        {
            state.Withdraw(amount);
            Console.WriteLine("取款金额为 {0:C}——", amount);
            Console.WriteLine("账户余额为 {0:C}", Balance);
            Console.WriteLine("账户状态为 {0}", state.GetType().Name);
            Console.WriteLine();
        }

        //获得利息
        public void PayInterest()
        {
            state.PayInterest();
            Console.WriteLine("利息");
            Console.WriteLine("账户余额为 {0:C}", Balance);
            Console.WriteLine("账户状态为 {0}", state.GetType().Name);
            Console.WriteLine();
        }
    }
}
