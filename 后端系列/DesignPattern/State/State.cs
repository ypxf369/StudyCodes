using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    /// <summary>
    /// 抽象状态类
    /// </summary>
    public abstract class State
    {
        public Account Account { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public decimal Balance { get; set; } = 0;
        /// <summary>
        /// 利率
        /// </summary>
        public decimal Interest { get; set; }
        /// <summary>
        /// 下限
        /// </summary>
        public decimal LowerLimit { get; set; }
        /// <summary>
        /// 上限
        /// </summary>
        public decimal UpperLimit { get; set; }

        /// <summary>
        /// 存钱
        /// </summary>
        /// <param name="amount"></param>
        public abstract void Deposit(decimal amount);

        /// <summary>
        /// 取钱
        /// </summary>
        /// <param name="amount"></param>
        public abstract void Withdraw(decimal amount);

        /// <summary>
        /// 利息
        /// </summary>
        public abstract void PayInterest();

        public virtual void ChangeState() 
        {
            if (Balance < 0)
            {
                Account.state = new RedState(this);
            }
            else if (Balance >= 0 && Balance < 1000)
            {
                Account.state = new SilverState(Balance, Account);
            }
            else if (Balance > 1000)
            {
                Account.state = new GoldState(this);
            }
        }
    }
}
