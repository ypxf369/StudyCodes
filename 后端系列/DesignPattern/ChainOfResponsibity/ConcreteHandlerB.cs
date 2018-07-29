using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibity
{
    /// <summary>
    /// 具体处理者B
    /// </summary>
    public class ConcreteHandlerB : Handler
    {
        public ConcreteHandlerB(string name) : base(name)
        {

        }
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request != null && request.Amount < 100000)
            {
                Console.WriteLine($"{nameof(ConcreteHandlerB)}处理了价格为{request.Amount}的请求");
            }
            if (NextHandler != null)
            {
                NextHandler.ProcessRequest(request);
            }
        }
    }
}
