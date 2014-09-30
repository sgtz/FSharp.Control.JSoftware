coclass'ioJd'

 s=:''

 svr=:'svr_new_svr.ijs'
 svrNme=:''
 startdir=:''
 port=:_1

 ctor=:3 : 0
  'svrnme bind prt u p'=.y
  'already initialized' assert _1=nc<'SKLISTEN_jhs_' NB. prevent damage to running JHS
 
  svrNme=:svrnme
  svr=:'server_',svrnme,'.ijs'
  port=:prt
 
  s=:s,'PORT_jhs_=:',(":port),LF		NB. 65019
  s=:s,'LHOK_jhs_=:0',LF
  s=:s,'BIND_jhs_=:''',bind,'''',LF 		NB. 'localhost'
  s=:s,'OKURL_jhs_=: a:',LF
  s=:s,'USER_jhs_=:''', u,'''',LF
  s=:s,'PASS_jhs_=:''', p,'''',LF
  s=:s,'load JDP,''api/jjd.ijs''',LF 		NB. serve JHS jjd requests from wget clients
  i.0 0
 )

 addDb=:3 : 0
  s=:s,'jdadmin''',y,'''',LF
  i.0 0
 )

 write=:3 : 0
  i.0 0[s fwrite JDP,'config/',svr
 )

writeShellCmd=:3 : 0
  'prj'=.y
  scr=.''
  scr=.scr,'title ',svrNme,':',(":port),' server',LF
  scr=.scr,'cmd /c "cd %homepath%\j64-802 && bin\j.exe ',prj,'\svr\start.ijs',' -js ""initserver '''
  scr_end=.''' """',LF
  i.0 0 [(scr,svrNme,scr_end) fwrite '~temp\start\',svrNme,'.csh'

  NB. @TODO: !!! may have to do this as a bat file !!!

  NB. @TODO: have a Unix / Windows setting for this

 )
i.0 0[cocurrent 'base'

NB. this script works correctly

NB. 38 C% more edu.bat
NB. REM C:\Users\Steven\j64-802\bin\jconsole.exe ~addons\ide\jhs\core.ijs -js " init_jhs_'' "
NB. C:\Users\Steven\j64-802\bin\jconsole.exe C:\dev\EXP\prj\geom\prj\edu\start.ijs -js " init_jhs_'' "
NB. 39 C%
NB.

