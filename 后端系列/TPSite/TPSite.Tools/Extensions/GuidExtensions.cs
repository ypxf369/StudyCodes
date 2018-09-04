using System;

namespace TPSite.Tools.Extensions
{
    public static class GuidExtensions
    {
        public static bool IsNullOrEmpty(this Guid guid)
        {
            return guid == Guid.Empty;
        }
    }
}
