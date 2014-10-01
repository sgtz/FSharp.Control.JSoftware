using System;
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
            var x = c.jd("eval 5+5");
            Console.WriteLine(x);
        }

        [TestMethod]
        public void CanEval2()
        {
            var x = c.j("5+5");
            Console.WriteLine(x);
        }


        [TestMethod]
        public void CanEval02()
        {
            var x = c.jd("eval 101+202", SvrFmt.Text);
            var s = (string) x;
            Assert.AreEqual("303",s);  
        }
        
        [TestMethod]
        public void CanSelect(){
            var s = c.jd("read from j", SvrFmt.Text, SvrFmt.JSON);
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
// @TODO: will nuget break a travis build?