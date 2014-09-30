NB. setup UserFolders_j_
erase'myProject'[defudir 'MyProject';myProject[require myProject,'/sys/j-env.ijs'[myProject=.'c:/dev/exp/prj/someProj'

NB. @TODO: dynamically put the github directory in the above line with environment variables across all OS types

NB. System Libraries
NB. ----------------

load'~addons/ide/jhs/core.ijs'
load'~addons/data/jd/jd.ijs'

NB. Libraries
NB. -------------


NB. Start Sequence
NB. --------------

load'~MyProject/init.ijs'

initserver'databaseName'    NB. see JD documentation for how to setup a database   
                            NB. provide additional guides + perhaps a few setup utility scripts
							
