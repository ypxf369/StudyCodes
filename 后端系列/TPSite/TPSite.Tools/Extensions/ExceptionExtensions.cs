using System;
using System.Runtime.ExceptionServices;

namespace TPSite.Tools.Extensions
{
    public static class ExceptionExtensions
    {
        public static void ReThrow(this Exception exception)
        {
            ExceptionDispatchInfo.Capture(exception).Throw();
        }
    }
}
