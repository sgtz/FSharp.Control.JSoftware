using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FSharp.Control.JSoftware.Test
{
    [TestClass]
    public class FmtTests
    {
        private bool Eq(byte[] a, byte[] b)
        {
            int i=0, i_ = a.Length, j_ = b.Length;
            if (i_ != j_)
            {
                return false;
            }
            else
            {
                for (; i < i_; i++)
                    if (a[i] != b[i])
                        return false;
            }
            return true;
        }
    
    }
}
