# Augmenting JD for JSON and Eval

JD has been put together in a flexible way, and the ease of making these modifications illustrates this.  
On the tojson verb, this was already a part of JD, but the line was missing from the source code for some reason (a bug?).

On Eval, this already exists as a "foreign" verb in J.  So we are merely taking advantage of this through the
JD extensions mechanism.  

You need to be security concious to take this approach, but extending J through a command driven rather than a completely RESTful
API approach may be of benefit on occassion.

## To add JSON Support
 
 1. load'~addons\data\jd\base\util.ijs' as part of your server startup script.  This loads in the tojson verb.

 2. insert one line into your JJD.ijs script
  
   a) jpath '~addons\data\jd\api\jjd.ijs'   NB. gets the actual location of this file on your hard drive
 
   b) insert the JSON line inside your jjd.ijs file

    select. fout
    case.'JBIN' do. 'application/octet-stream' gsrcf 3!:1 d
    case.'JSON' do. 'application/json' gsrcf tojson_jd_ d     NB. <---- **** INSERT THIS LINE HERE ****
    case.'TEXT' do. 'text/plain' gsrcf totext_jd_ d

## To add Eval Support
  
   @TODO: add information for eval support

## To add JBinary support

   through taking a dependency on J through COM, there was a version of this code available that utilised JBIN.

   However, this dependency (and associated code) was taken out so that a simpler out-of-process IPC approach could be put in place.  
   The direction that JD is taking on this appears to be the right one in my honest opinion.