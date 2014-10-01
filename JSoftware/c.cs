using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace FSharp.Control.JSoftware
{
    /// <summary>
    /// connector teathers to a host with a user, password, and database
    /// If no user / password specified the default "u/p" is assumed
    /// If no serialisation method is specified, (in:TEXT, out:JSON) is assumed.
    /// NB. only TEXT/JSON is currently supported (see modification to the JD script needed for JSON support above)
    /// NB. an earlier version of this connector hacked in JBIN support through a COM / J6 / client-side COM
    ///     technique, but that code was removed so that there were a minimal number of dependencies.
    ///     @TODO: add JBIN support natively.  ie. unravel the JBIN structure directly in .Net, or
    ///            through pinvoke.  The COM wrapper worked fine, but COM support has an unkown future,
    ///            and also is a windows only solution.
    /// 
    /// </summary>
    public class c
    {
        // @TODO: is there a way to add references to GitHub projects dynamically from other solutions?  ie. if using the User folder default, then the location will differ between machines

        // @TODO: change return data to a stream

        private readonly CxInfo _cxInfo;
        private readonly Sockets2 _socket = new Sockets2();
        private readonly ASCIIEncoding _ascii = new ASCIIEncoding();

        private SerInfo _serInfo = new SerInfo(SvrFmt.Text, SvrFmt.JSON);
        private const string cDefUsr = "u";
        private const string cDefPwd = "p";

        public c(string h, int p, string db, string usr, string pwd)
            : this(new CxInfo(h, p, db, usr, pwd), null)
        {}
        public c(string h, int p, string db, string usr, string pwd, SvrFmt fin, SvrFmt fout)
            : this(new CxInfo(h, p, db, usr, pwd), new SerInfo(fin,fout))
        {}

        public c(string h, int p, string db)
            : this(h, p, db, cDefUsr, cDefPwd)
        {}

        public c(CxInfo cxInfo, SerInfo serInfo)
        {
            _cxInfo = cxInfo;
            if (serInfo != null)
            {
                _serInfo = serInfo;
            }
        }

        public object jd(string s)
        {
            return jd(s, _serInfo);
        }
        public object jd(string s, SvrFmt fin, SvrFmt fout)
        {
            return jd(s, new SerInfo(fin,fout));
        }
        public object jd(string s, SvrFmt fout)
        {
            return jd(s, new SerInfo(SvrFmt.Text,fout));
        }

        public CxInfo CxInfo
        {
            get
            {
                return _cxInfo;
            }
        }

        public SerInfo SerInfo { get { return _serInfo; } set { _serInfo = value; } }

        public object jd(string s, SerInfo ser)
        {
            // @TODO: reimplement different serialization strategies
            // @TODO: reimplement table conversion

            var request = _ascii.GetBytes(s);
            var response = jjd(_cxInfo, ser, request);
            return _ascii.GetString(response);
        }

        protected byte[] jjd(CxInfo cx, SerInfo ser, byte[] body)
        {
            return jjd(cx.Uri, cx.Db, cx.Usr, cx.Pwd, ser.In, ser.Out, body);
        }

        /// <summary>
        /// IMPORTANT: usr and pwd are not encrypted.  Use SSL.  
        /// </summary>
        protected byte[] jjd(Uri srv, string db, string usr, string pwd, SvrFmt fin, SvrFmt fout, byte[] body)
        {
            var toAddr = new Uri(srv, "jjd");

            var header = ToHeader(db, usr, pwd, z.toString(fin), z.toString(fout));
            var msg = z.CombineBytes(header, body);

            byte[] response;
            var result = _socket.wget(toAddr, null, msg, out response);
            if (!result.Contains("OK"))
            {
                throw new Exception(result);   // @TODO: make a better exception msg
            }
            return response;
        }

        protected byte[] ToHeader(CxInfo conn, string fin, string fout)
        {
            return ToHeader(conn.Db, conn.Usr, conn.Pwd, fout, fin);
        }

        protected byte[] ToHeader(string db, string usr, string pwd, string fin, string fout)
        {
            // see: client.ijs & jjd.ijs
            /// 'fin fout dbx user pswd'
            /// user field is user/pswd and pswd field is not used
            var up = (String.IsNullOrEmpty(usr) ? "" : usr) + (String.IsNullOrEmpty(pwd) ? "" : ("/" + pwd));
            var s = string.Format("{0};{1};{2};{3};;*", fin, fout, db, up);
            return _ascii.GetBytes(s);
        }
    }

    public enum SvrFmt { Text, JSON, JBinary }

    /// <summary>
    /// Serialization Info
    /// </summary>
    public class SerInfo
    {
        private readonly SvrFmt _fin;
        private readonly SvrFmt _fout;

        public SerInfo(SvrFmt fin, SvrFmt fout)
        {
            _fin = fin;
            _fout = fout;
        }

        public SvrFmt In { get { return _fin; } }
        public SvrFmt Out { get { return _fout; } }

    }

    /// <summary>
    /// Connection Info
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{DiagInfo,nq}")]
    public class CxInfo
    {

        public CxInfo()
        {
        }

        public CxInfo(CxInfo cx, string db)
            : this(cx.Host, cx.Port, db, cx.Usr, cx.Pwd)
        {
        }

        public CxInfo(CxInfo cx, string db, string usr, string pwd)
            : this(cx.Host, cx.Port, db, usr, pwd)
        {
        }

        public CxInfo(string host, int port, string db)
            : this(host, port, db, "u", "p")
        { }

        public CxInfo(string host, int port)
            : this(host, port, "", "u", "p")
        {
        }

        public CxInfo(string host, int port, string db, string usr, string pwd)
        {
            this.Host = HostDefault(host);
            this.Port = port;
            this.Db = db;
            this.Usr = usr;
            this.Pwd = pwd;
        }

        private string HostDefault(string host)
        {
            var s=String.IsNullOrWhiteSpace(host) ? "127.0.0.1" : host;   // NB. 127.0.0.1 is localhost
            if (!s.StartsWith("http"))
            {
                if (Ssl)
                    return "https://" + s;
                else
                    return "http://" + s;
            }
            else
                return s;
        }

        public CxInfo(Uri uri, string db, string usr, string pwd)
        {
            this.Host = uri.Host;
            this.Port = uri.Port;
            this.Db = db;
            this.Usr = usr;
            this.Pwd = pwd;
        }

        public string Host { get; set; }

        public int Port { get; set; }

        public Uri Uri { 
            get { 
                return new Uri(Host + ":" + Port); 
            } 
        }
        public string Db { get; set; }
        public string Usr { get; set; }
        public string Pwd { get; set; }

        public bool Ssl { get; set; }

        public string DiagInfo { get { return ToString(); } }

        public override string ToString()
        {
            return String.Format("srv:{0}, db:{1}, usr:{2}, pwd:{3}", Uri == null ? "null" : Uri.ToString(), Db, Usr, Pwd);
        }
    }

    public class Sockets2
    {

        public void wget(string uri)
        {
            //return wget(new Uri(uri));
        }

        /// <summary>
        /// Reads data from a stream until the end is reached. The
        /// data is returned as a byte array. An IOException is
        /// thrown if any of the underlying IO calls fail.
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        public static byte[] ReadFully(Stream stream)
        {
            var buffer = new byte[4096]; // 32768
            using (var ms = new MemoryStream())
            {
                while (true)
                {
                    var read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }

        public class NoBypassProxy : IWebProxy
        {
            private readonly IWebProxy _proxy;

            public NoBypassProxy(IWebProxy proxy)
            {
                _proxy = proxy;
            }

            public Uri GetProxy(Uri destination)
            {
                return _proxy.GetProxy(destination);
            }

            public bool IsBypassed(Uri host)
            {
                return false;
            }

            public ICredentials Credentials { get { return _proxy.Credentials; } set { _proxy.Credentials = value; } }

            public override string ToString()
            {
                return _proxy.ToString();
            }

            public override bool Equals(object obj)
            {
                return _proxy.Equals(obj);
            }

            public override int GetHashCode()
            {
                return _proxy.GetHashCode();
            }
        }

        public string wget(Uri uri, IEnumerable<KeyValuePair<string, string>> headerKvPairs, byte[] requestBody, out byte[] responseBody)
        {

            //var host = uri.Host + ((uri.Port > 0) ? ":" + uri.Port.ToString() : "");
            //var newRelUri = new Uri(uri.PathAndQuery, UriKind.Relative);

            ServicePointManager.Expect100Continue = false;

            var request = (HttpWebRequest)WebRequest.Create(uri);

            //request.Host = host;
            //request.RequestUri = newRelUri;

            //request.KeepAlive = false;
            //request.Proxy = WebProxy.GetDefaultProxy();
            //request.Proxy = new WebProxy(uri);
            //proxy = request.Proxy;
            //request.Proxy = new NoBypassProxy(request.Proxy);
            //request.Proxy = WebRequest.GetSystemWebProxy();

            request.Method = "POST";
            //request.ContentType = "application/octet-stream";
            //request.ContentLength = requestBody.Length;

            if (headerKvPairs != null)
            {
                foreach (var headerPair in headerKvPairs)
                {
                    request.Headers.Add(headerPair.Key, headerPair.Value);
                }
            }

            var requestBodyStream = request.GetRequestStream();
            requestBodyStream.Write(requestBody, 0, requestBody.Length);
            requestBodyStream.Close();

            var response = (HttpWebResponse)request.GetResponse();

            var status = response.StatusCode.ToString();

            var responseStream = response.GetResponseStream();

            responseBody = ReadFully(responseStream);

            if (responseStream != null)
                responseStream.Close();

            return status;
        }

    }

    public static class z
    {
        public static string toString(SvrFmt typ)
        {
            switch (typ)
            {
                case SvrFmt.Text:
                    return "TEXT";
                case SvrFmt.JSON:
                    return "JSON";
                case SvrFmt.JBinary:
                    return "JBIN";
                default:
                    throw new ArgumentOutOfRangeException("typ");
            }
        }
        public static string dsQ(string s) { return "''" + (s ?? "") + "''"; }
        public static string sQ(string s) { return "'" + (s ?? "") + "'"; }
        public static bool Contains(byte[] src, byte[] toFind)
        {
            return Find(src, toFind) > -1;
        }

        public static int Find(byte[] src, byte[] toFind)
        {
            var index = -1;
            var matchIndex = 0;

            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] == toFind[matchIndex])
                {
                    if (matchIndex == (toFind.Length - 1))
                    {
                        index = i - matchIndex;
                        break;
                    }
                    matchIndex++;
                }
                else
                {
                    matchIndex = 0;
                }
            }
            return index;
        }

        public static byte[] CombineBytes(byte[] a, byte[] b)
        {
            byte[] msg;
            using (var ms = new MemoryStream())
            {
                ms.Write(a, 0, a.Length);
                ms.Write(b, 0, b.Length);

                msg = ms.ToArray();
            }
            return msg;
        }
    }

}
