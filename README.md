#FSharp.Control.JSoftware

Text a JD SQL-esque request and receive a JSON response.

FSharp.Control.JSoftware is an out-of-process connector to JSoftware.com's columnar JD database (see jsoftware.com).  

This connector can also be used to expose J functions over http.

##How To Use

1. new up a c class instance, 

2. send off some requests with c.jd("some command")

3. consume the response

##Examples

###Standard

      var c = c("host",65031,"sandp","u","p")  // ie. (host,port,db,usr,pwd)
      var r = c.jd("reads from j")

###Explicit Serialisation

      var c = c("host",65031,"sandp","u","p",SvrFmt.Text,SvrFmt.JSON)
      var r = c.jd("reads from j")

###Per Request Serialisation

      var c = c("host",65031,"sandp","u","p")
      var r = c.jd("reads from j",SvrFmt.Text,SvrFmt.JSON) 

###Defaults

1. If no user / password is specified then the default of "u/p", or in other words a user called "u" and a password of "p" is used. 

2. When no serialisation strategy is specified, (in:TEXT,out:JSON) is assumed


##Helpers

 **CxInfo**  : connection information

 **SerInfo** : serialisation strategy choices of (fin,fout) where f stands for format.


#Setup

To enable JSON on JD, you will need to a single lind to the ~addons\data\jd\api\jjd.ijs (see JsonAndEval.md) 

#Misc

1. c.cs will likely be translated to F# in future.  Even so, significant extension work will be done in F#.  So, FSharp... will become the better label.

2. Every effort will be made to keep the connector CLR friendly, so that language choice will not be an issue.

3. Only TEXT/TEXT and TEXT/JSON are currently supported.  JBIN was working, but these elements were removed so that the first 
release could be as simple as possible while still remaining useful.

#Architecture

You might want to migrate to a J based RESTful approach in the future, or your REST layer might make JD SQLesque 
requests or hook into your connection exposed API (akin to a stored procedure).  In this context the use case is indistinguishable from any other database -> SQL or stored procedure idiom,
except you've got a very capable analytics language to express your ideas in.

#Licence

Appache 2.0 
