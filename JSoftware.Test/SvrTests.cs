using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FSharp.Control.JSoftware.Test
{
    [TestClass]
    public class SvrTests
    {
        private c c;
        [TestInitialize]
        public void Scaffolding()
        {
            c = new c("", 65031, "edu");
        }

        [TestMethod]
        public void CanEval()
        {
            // NB. eval only works if you've enabled this on your server
            // NB. @TODO: document how to do this
            var c = new c("", 65031, "edu");
            var x = c.jd("eval 5+5");
        }




    }
}
