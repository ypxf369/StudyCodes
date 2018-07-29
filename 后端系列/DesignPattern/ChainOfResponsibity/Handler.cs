using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibity
{
    /// <summary>
    /// 抽象处理者
    /// </summary>
    public abstract class Handler
    {
        public string Name { get; set; }
        public  Handler NextHandler { get; set; }

        protected Handler(string name)
        {
            this.Name = name;
        }

        public abstract void ProcessRequest(PurchaseRequest request);
    }
}
