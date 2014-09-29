J8L
===

JLight is an out-of-process connector to JSoftware.com's Columnar database known as JD, or simply, J Database.

Send reqeust "commands" in text format.  Receive responses in JSON.


How it works:

Through the c.cs .ctor arguments, the connector will be teathere itself to: host, password, database
If no user / password is specified the default "u/p" is assumed
If no serialisation strategies are specified, in:TEXT and out:JSON are assumed.


Important:

only TEXT/JSON is supported currently

JBIN was working, but those were ripped out with the aim that the first public C# http API 
that I publish should be as simple as possible.

Alternative uses:

* the connector can also be used to expose J functions over http.  
  
  While this is not a RESTful technique, it can be useful.


TODO:

* describe how to setup a JD database so that it can expose arbitrary functions 

* implement the JBinary format

Misc:

* the c.cs might be converted to F# in future.  Even so, extensions using this connector will be built in F#.  This is 
  the current rationale for have FSharp.Control.JSoftware as the namespace.

Licence:

Appache ... 