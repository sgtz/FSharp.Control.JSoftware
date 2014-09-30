NB. FOLDERS
defudir=:3 : 0
 L=.{.|: }:"1 UserFolders_j_
 row=.((nme=.>0{y);(fldr=.normdir >1{y))
 if. (3=count y) do. frc=.>2{y else. frc=.0 end.   
 i=.L find <nme
 if. frc +. i = count L do.
   if. i < count L do.
     UserFolders_j_=:row (i)}UserFolders_j_
   else.
     UserFolders_j_=:UserFolders_j_,row
   end.
 else.
   curr=.>i{L,<'~not found~'
   if. not (<fldr) match curr do.
      err=.'you tried to set user folder ',(quote nme),' with ',fldr,', but it is already ',(quote curr),'.  Use the force option.' 
      type_jthrow_=: err throw.
      NB. define the force option
   NB. else.
      NB. defining the same thing twice is okay
   end.
 end.
 i. 0 0
)

ludir=:3 : '[UserFolders_j_'
rmudir=:3 : 0
 UserFolders_j_ find y
)


defsysdir=:3 : 0
 L=.{.|: }:"1 SystemFolders_j_
 row=.((nme=.>0{y);(fldr=.normdir >1{y))
 if. (3=count y) do. frc=.>2{y else. frc=.0 end.  
 i=.L find <nme
 if. frc +. i = count L do.
   if. i < count L do.
     SystemFolders_j_=:row (i)}SystemFolders_j_
   else.
     SystemFolders_j_=:SystemFolders_j_,row
   end.
 else.
   curr=.i{L,<'~not found~'
   if. not (<fldr) match curr do.
      err=.'you tried to set system folder ',(quote nme),' with ',fldr,', but it is already ',(quote curr),'.  Use the force option.' 
      type_jthrow_=:err throw.
      NB. define the force option
   NB. else.
     NB. defining the same thing twice is okay
   end.
 end.
 i.0 0
)

rmudir=:3 : 0
 i.0 0[UserFolders_j_=:UserFolders_j_ #~ not (<>y)="(0 1) {.|:UserFolders_j_
)

rmsysdir=:3 : 0
 i.0 0[SystemFolders_j_=:SystemFolders_j_ #~ not (<>y)="(0 1) {.|:SystemFolders_j_
)

lsysdir=:3 : '[SystemFolders_j_'