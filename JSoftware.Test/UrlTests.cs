using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FSharp.Control.JSoftware.Test
{
    public class UrlTests
    {
        [TestMethod]
        public void CanSetBasicConnectionInfo()
        {
            var c = new c("", 65031, "edu");

            var cx = c.CxInfo;
            var uri = cx.Uri;
        }

        [TestMethod]
        public void Test03()
        {
            // Create a new 'Uri' object with the specified string.
            Uri myUri = new Uri("http://www.contoso.com");
            // Create a new request to the above mentioned URL.	
            WebRequest myWebRequest = WebRequest.Create(myUri);

        }

        [TestMethod]
        public void Test04()
        {
            // Create a new 'Uri' object with the specified string.
            Uri myUri = new Uri("http://www.contoso.com/abc");
            // Create a new request to the above mentioned URL.	
            WebRequest myWebRequest = WebRequest.Create(myUri);

        }

        [TestMethod]
        public void Test05()
        {
            // Create a new 'Uri' object with the specified string.
            Uri myUri = new Uri("http://127.0.0.1/abc");
            // Create a new request to the above mentioned URL.	
            WebRequest myWebRequest = WebRequest.Create(myUri);

        } 
    }
}