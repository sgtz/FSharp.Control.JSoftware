#r"bin/debug/FSharp.Control.JSoftware.dll"
open FSharp.Control.JSoftware

// pretty print for the c type
fsi.AddPrinter(fun (x:c)->sprintf "((\"%s\",\"%s\",\"%s\"),(\"%s\",\"%s\"))" (x.CxInfo.Uri.ToString()) x.CxInfo.Usr x.CxInfo.Pwd (x.SerInfo.In.ToString()) (x.SerInfo.Out.ToString()))
let c = new c("",65015,"sandp")
let J = c.j
let JD = c.jd

// paren style
let r1 = c.jd("eval 1+1")
let r2 = c.j("1+1")
let r3 = c.j("reads from j")

// closure + non-paren style
let r11 = J "1+1"
let r12 = JD "eval 1+1"
let r13 = JD "reads from j"

// misc
let r21 = J "i. 3 3"   // output looks like it should be inverted.  ie. 0 1 2 should be a row

let r22 = J "|: i. 3 3"