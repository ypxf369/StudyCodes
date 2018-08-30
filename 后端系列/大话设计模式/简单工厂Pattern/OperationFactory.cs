using System;
using System.Collections.Generic;
using System.Text;

namespace 简单工厂Pattern
{
    public class OperationFactory
    {
        public static Operation GetOperationObj(double a, double b, string operation)
        {

            switch (operation)
            {
                case "+":
                    return new AddOperation(a, b);
                case "-":
                    return new JianOperation(a, b);
                case "*":
                    return new ChengOperation(a, b);
                case "/":
                    return new ChuOperation(a, b);
                default:
                    return null;
            }
        }
    }
}
