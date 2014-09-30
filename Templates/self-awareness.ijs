erase'projectDir'[defudir 'MyProj';projectDir[require projectDir,'/sys/j-env.ijs'[projectDir=.'c:/dev/exp/prj/someProj'

0 : 0

benefits: 
* make deployment of your work easier.  
* perhaps you might end up using the JConsole 

How:

Make your scripts self-aware (perhaps 'contextually aware' is more apt).

Drop this one line into the start of your script.  This is a short way of providing project structure and folder location independence.

From there, you can define you script dependencies more flexibly through 'load' or 'require' through the UserFolder / SystemFolder syntax of '~MyProj/some/path/from/a/root/to/a/file.ijs'.  We are just achieving a convenient way of bootstrapping this feature.  

Other options might include environment variables.  

@TODO: myProject dir could also be initialised with some OS system variables (see 2!:5 y / Getenv)
@TODO: shorten the script self-awareness line
@TODO: include 2!:5 y Getenv.  
@TODO: include an OS system variable approach here instead of semi-hard wiring folders (even if one line).
@TODO: find a generic way to bootstrap a script with a UserFolder_j_, and push this to the J distribution if not already there.
)