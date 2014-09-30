FSharp.Control.JSoftware
========================

FSharp.Control.JSoftware is an out-of-process connector to JSoftware.com's columnar JD database (see jsoftware.com).

Send SQL-esque requests in text format and receive responses in JSON.

This connector can also be used to expose J functions over http.  While this is not RESTful as such, it can be convenient.

How to use
----------

new up a c class instance, send off some requests with c.jd("some command"), and then consume the return values.

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


###Helpers

    CxInfo  : connection information

    SerInfo : serialisation strategy choices of (fin,fout) where f stands for format.


###Setup

To enable JSON on JD, you will need to a single lind to the ~addons\data\jd\api\jjd.ijs (see JsonAndEval.md) 

###Discussion

    only TEXT/TEXT and TEXT/JSON are currently supported.  

    JBIN was working, but these elements were ripped out so that the first 
    release could be as simple as possible.


###Misc

About the FSharp.Control.JSoftware namespace.  c.cs will likely be translated to F# in future.  Even so, significant extension work will be done in F#.  So, F# will become the better label.

Every effort will be made to keep the connector CLR friendly, so that language choice will not be an issue.

###Architecture

You might want to migrate to a J based RESTful approach in the future, or your REST layer might make JD SQLesque 
requests or hook into your connection exposed API (akin to a stored procedure).  In this context the use case is indistinguishable from any other database -> SQL or stored procedure idiom,
except you've got a very capable analytics language to express your ideas in.

###Licence

Appache 2.0 
