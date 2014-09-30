coclass'ioJdAuth'

L=:''

ctor=: 3 : 0
 dbname=:y
 i.0 0
)

SQ=:''''
sq=:13 : 'SQ,y,SQ'

add=: 3 : 0
 'role ops UP'=.y
 
 L=:L,(sq role),' jdadminup ',(sq ''),LF    NB. authentication
 L=:L,(sq role),' jdadminup ',(sq UP),LF    NB. authentication
 L=:L,(sq role),' jdadminop ',(sq ops),LF   NB. authorisation     
 i.0 0
)

write=: 3 : 0
 pth=.'~temp/jd/',dbname,'/admin.ijs'
 i.0 0[L fwrite pth    NB. to access with remote sessions
 NB. 'wrote permissions to: ',pth
 i. 0 0
)

i.0 0[cocurrent 'base'

NB.  'all' '*' 'u/p' 
NB.  'ro'  'read reads' 'abc/def ghi/jkl'
