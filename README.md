FSharp.Control.JSoftware
========================

FSharp.Control.JSoftware is an out-of-process connector to JSoftware.com's Columnar database known as JD, or simply, J Database.

Send reqeust "commands" in text format.  Receive responses in JSON.


How it works:

create a new c instance (c.cs) and provide the desired host parameters. Now you can execute commands with c.jd("some command").

If no user / password is specified then the default of "u/p" is assumed
When no serialisation strategies are specified, in:TEXT and out:JSON are assumed.


Notes:

only TEXT/TEXT and TEXT/JSON are currently supported.  Also, you will need to add one line to a script in the ~addons/data/jd folder to enable JSON

JBIN was working, but these elements were ripped out with the aim that the first 
release should be as simple as possible.

Alternative uses:

* the connector can also be used to expose J functions over http.  While this is not a RESTful technique, it can be very useful.


TODO:

* implement the JBinary format

Misc:

* the c.cs will likely be converted to F# in future.  Even so, extensions using this connector will be done in F#.  So that's why FSharp.Control.JSoftware was used as a namespace.

Licence:

Appache 2.0 