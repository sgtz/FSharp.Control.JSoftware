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

        //private ASCIIEncoding _ascii = new ASCIIEncoding();
        //[TestMethod]
        //public void GetBytesTechniquesAreEquivilent()
        //{
        //    var a = z.GetBytes("abcdef");
        //    var b = _ascii.GetBytes("abcdef");
        //    Assert.AreEqual(true, Eq(a,b));
        //}
        //[TestMethod]
        //public void GetStringTechniquesAreEquivilent()
        //{
        //    var x = z.GetBytes("abcdef");
        //    var a = _ascii.GetString(x);
        //    var b = z.GetString(x);
        //    Assert.AreEqual(true, a==b);
        //}
    
    }
}
