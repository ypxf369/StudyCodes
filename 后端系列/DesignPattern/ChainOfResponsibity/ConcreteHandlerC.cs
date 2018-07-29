using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibity
{
    /// <summary>
    /// 具体处理者C
    /// </summary>
    public class ConcreteHandlerC : Handler
    {
        public ConcreteHandlerC(string name) : base(name)
        {

        }
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request != null && request.Amount > 100000)
            {
                Console.WriteLine($"{nameof(ConcreteHandlerC)}处理了价格为{request.Amount}的请求");
            }
            if (NextHandler != null)
            {
                NextHandler.ProcessRequest(request);
            }
        }
    }
}
