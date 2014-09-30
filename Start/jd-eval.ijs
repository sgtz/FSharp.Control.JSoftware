defudir 'ExGeom';'c:\dev\exp\prj\geom\prj'
require '~ExGeom/edu/init.ijs'

NB. a sprinkling of Q inspired functions
NB. ------------------------------------
ltrim=: }.~ +/@(*./\)@(' '&=) : [:
rtrim=: }.~ -@(+/)@(*./\.)@(' '&=) : [:
trim=: ltrim@:rtrim f. : [:
where=:[:I.[
not=:[:-.[
except=:(13 : 'x{~ where not x=y' f.)
ssr=:13 : 'x stringreplace~ y'   NB. string search and replace
NB. -----------------------------------------------------------

NB. The body
NB. --------
evalb_base_=: 3 : '". y'  NB. eval block
evals_base_ =:  3 : '(".) each a: except~<@trim;._1 LF,(TAB,'' '') ssr~ y'           NB. eval_lines
jd_evals_jd_=:evals_base_
eval_base_ =:  3  : '>{.evals_base_ y'                                               NB. eval
jd_eval_jd_=:eval_base_
jd_evalb_jd_=:evalb_base_
