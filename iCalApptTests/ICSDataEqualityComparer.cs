using System;
using System.Collections.Generic;
using iCalApp;

namespace iCalApptTests
{
    public class ICSDataEqualityComparer : IEqualityComparer<ICSData>
    {
        public bool Equals(ICSData x, ICSData y)
        {
            if (x == null && y == null)
                return true;

            if (x == null ^ y == null)
                return false;

            var isEqual = x.IsValid == y.IsValid && x.ErrorText == y.ErrorText;

            return isEqual;
        }

        public int GetHashCode(ICSData obj)
        {
            throw new NotImplementedException();
        }
    }
}
