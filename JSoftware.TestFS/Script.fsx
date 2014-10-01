#r"bin/debug/FSharp.Control.JSoftware.dll"
open FSharp.Control.JSoftware

// pretty print for the c type
fsi.AddPrinter(fun (x:c)->sprintf "((\"%s\",\"%s\",\"%s\"),(\"%s\",\"%s\"))" (x.CxInfo.Uri.ToString()) x.CxInfo.Usr x.CxInfo.Pwd (x.SerInfo.In.ToString()) (x.SerInfo.Out.ToString()))

let c = new c("",65015,"sandp")

let r = c.jd("eval 1+1")

let r = c.j("1+1")


