using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibity
{
    /// <summary>
    /// 具体处理者A
    /// </summary>
    public class ConcreteHandlerA : Handler
    {
        public ConcreteHandlerA(string name) : base(name)
        {

        }
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request != null && request.Amount < 25000)
            {
                Console.WriteLine($"{nameof(ConcreteHandlerA)}处理了价格为{request.Amount}的请求");
            }
            if (NextHandler != null)
            {
                NextHandler.ProcessRequest(request);
            }
        }
    }
}
