erase'projectDir'[defudir 'MyProj';projectDir[require projectDir,'/sys/j-env.ijs'[projectDir=.'c:/dev/exp/prj/someProj'

0 : 0

Make your scripts self-aware (perhaps 'contextually aware' is more apt).

Drop this one line into the start of your script.  A minimal way of providing project structure.  Minimal structure and folder location independence.  

note: myProject dir could be initialised with some OS system (see 2!:5 y / Getenv)

use J verb 'load' or 'require' with the ~MyProj prefix as defined on the first line of the script.

Other options might include environment variables.  

@TODO: shorten the script self-awareness line
@TODO: include 2!:5 y Getenv.  
@TODO: include an OS system variable approach here instead of semi-hard wiring folders (even if one line).
@TODO: find a generic way to bootstrap a script with a UserFolder_j_, and push this to the J distribution if not already there.
)