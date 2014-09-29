using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FSharp.Control.JSoftware.Test
{
    [TestClass]
    public class SAndPTests
    {
        private c c;
        [TestInitialize]
        public void Scaffolding(){
            c = new c("", 65015, "sandp");
        }

        [TestMethod]
        public void CanEval(){
            // NB. eval only works if you've enabled this on your server
            // NB. @TODO: document how to do this
            var x = c.jd("eval 5+5");
        }

        [TestMethod]
        public void CanEval02()
        {
            // NB. eval only works if you've enabled it on your server
            // NB. @TODO: document how to do this
            var x = c.jd("eval 101+202", SvrFmt.Text);
            var s = (string) x;
            Assert.AreEqual("303",s);

            // @TODO: why is the evaluated data comming back as having \n after each character?
        }
        
        [TestMethod]
        public void CanSelect(){
            var s = c.jd("read from j", SvrFmt.Text, SvrFmt.JSON);
            // USE READS
        }
        [TestMethod]
        public void CanSelect02(){
            var s = c.jd("reads from j", SvrFmt.Text, SvrFmt.JSON);
            // @TODO: convert to JSON using JSON.Net
        }

      

        [TestMethod]
        public void CanSelect03()
        {
            var s = c.jd("reads from j", SvrFmt.Text, SvrFmt.Text);
        }

    }
}
