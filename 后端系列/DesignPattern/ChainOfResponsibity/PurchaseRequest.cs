using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibity
{
    /// <summary>
    /// 采购请求
    /// </summary>
    public class PurchaseRequest
    {
        public string Name { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public double Amount { get; set; }

        public PurchaseRequest(string name, double amount)
        {
            this.Name = name;
            this.Amount = amount;
        }

    }
}
