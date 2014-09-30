FSharp.Control.JSoftware
========================

FSharp.Control.JSoftware is an out-of-process connector to JSoftware.com's columnar database known as JD, or simply, J Database.

Send request "commands" in text format.  Receive responses in JSON.

The connector can also be used to expose J functions over http.  While this is
 not RESTful, it can be very convenient.


How to use:

new up a c class instance and then send off some requests with c.jd("some command"), then consume the return values.

example 1:

var c = c("host",65031,"sandp","u","p")  // ie. (host,port,db,usr,pwd)

c.jd("reads from j")

example 2:

var c = c("host",65031,"sandp","u","p",SvrFmt.Text,SvrFmt.JSON)

c.jd("reads from j")

example 3:

var c = c("host",65031,"sandp","u","p")

c.jd("reads from j",SvrFmt.Text,SvrFmt.JSON)   // a per command serialisation strategy.


Shorthand:

CxInfo -- place connection info in here and ctor

SerInfo -- serialisation strategy.  See fin / fout in JD documentation


Defaults:

If no user / password is specified then the default of "u/p" is assumed.

When no serialisation strategies are specified, in:TEXT and out:JSON are assumed


Setup:

You will need to add one line to a script in the ~addons/data/jd folder to enabl
e JSON.

Start with (Text,Text) first to prove you can connect and receive.


Discussion:

only TEXT/TEXT and TEXT/JSON are currently supported.  

JBIN was working, but these elements were ripped out so that the first 
release could be as simple as possible.


Misc:

* the c.cs will likely be converted to F# in future.  Even so, extensions using this connector will be done in F#.  So that's why FSharp.Control.JSoftware was used as a namespace.


Licence:

Appache 2.0 
