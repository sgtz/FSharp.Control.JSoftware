FSharp.Control.JSoftware
========================

FSharp.Control.JSoftware is an out-of-process connector to JSoftware.com's columnar database known as JD, or simply, J Database (see jsoftware.com).

Send sql-esque requests in text format.  Receive responses in JSON.

The connector can also be used to expose J functions over http.  While this is not RESTful, it can be very convenient.


How to use
----------

new up a c class instance and then send off some requests with c.jd("some command"), then consume the return values.

*example 1*

    var c = c("host",65031,"sandp","u","p")  // ie. (host,port,db,usr,pwd)

    var r = c.jd("reads from j")

*example 2*

    var c = c("host",65031,"sandp","u","p",SvrFmt.Text,SvrFmt.JSON)

    var r = c.jd("reads from j")

*example 3*

    var c = c("host",65031,"sandp","u","p")

    var r = c.jd("reads from j",SvrFmt.Text,SvrFmt.JSON)   // a per command serialisation strategy.

###Defaults

1. If no user / password is specified then the default of "u/p", or in other words a user called "u" 
and a password called "p". 

2. When no serialisation strategies are specified, in:TEXT and out:JSON are assumed


###Shorthand

    CxInfo  : connection information

    SerInfo : serialisation strategy choices of (fin,fout) where f stands for format.


###Setup

You will need to add one line to a script in the ~addons/data/jd folder to enabl
e JSON.

Start with (Text,Text) first to prove you can connect and receive.


###Discussion

    only TEXT/TEXT and TEXT/JSON are currently supported.  

    JBIN was working, but these elements were ripped out so that the first 
    release could be as simple as possible.


###Misc

About the FSharp.Control.JSoftware namespace.  c.cs will likely be translated to F# in future.  Even so, significant extension work will be done in F#.  So, F# will become the better label.

Every effort will be made to keep the connector CLR friendly, so that language choice will not be an issue.

###Licence

Appache 2.0 
