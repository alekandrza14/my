FileCreateDir, "C:/MyEngine"

prewkeya = 0
prewkeyb := 0
prewkeys := 0
prewkeyd := 0
prewkeyf := 0
prewkeyj := 0


FileAppend,%prewkeya%,C:/MyEngine/input_init.sig



w up::
FileAppend," ",C:/MyEngine/input_nsig.sig

prewkeya = 0
return
s up::
FileAppend," ",C:/MyEngine/input_nsig1.sig

prewkeyb = 0
return
d up::
FileAppend," ",C:/MyEngine/input_nsig2.sig

prewkeyc = 0
return
a up::
FileAppend," ",C:/MyEngine/input_nsig3.sig

prewkeyd = 0
return
e up::
FileAppend," ",C:/MyEngine/input_nsig4.sig

prewkeyf = 0
return
q up::
FileAppend," ",C:/MyEngine/input_nsig5.sig

prewkeyj = 0
return



w::
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_forward.sig
FileDelete,C:/MyEngine/input_sig.sig
prewkeya = 1
wasd(prewkeya,prewkeyb,prewkeyc,prewkeyd,prewkeyf,prewkeyj)

return


s::
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_back.sig
FileDelete,C:/MyEngine/input_sig.sig
prewkeyb = 1
wasd(prewkeya,prewkeyb,prewkeyc,prewkeyd,prewkeyf,prewkeyj)

return

d::

FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_right.sig
FileDelete,C:/MyEngine/input_sig.sig
prewkeyc = 1
wasd(prewkeya,prewkeyb,prewkeyc,prewkeyd,prewkeyf,prewkeyj)
return

a::
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_left.sig
FileDelete,C:/MyEngine/input_sig.sig
prewkeyd = 1
wasd(prewkeya,prewkeyb,prewkeyc,prewkeyd,prewkeyf,prewkeyj)

return

Up::
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_forward1.sig
FileDelete,C:/MyEngine/input_sig.sig

return


Down::
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_back1.sig
FileDelete,C:/MyEngine/input_sig.sig


return

Right::
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_right1.sig
FileDelete,C:/MyEngine/input_sig.sig


return

Left::
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_left1.sig
FileDelete,C:/MyEngine/input_sig.sig
prewkeyd = 1


return

e::
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_up.sig
FileDelete,C:/MyEngine/input_sig.sig
prewkeyf = 1
wasd(prewkeya,prewkeyb,prewkeyc,prewkeyd,prewkeyf,prewkeyj)
return

q:: 
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_down.sig
FileDelete,C:/MyEngine/input_sig.sig
prewkeyj = 1
wasd(prewkeya,prewkeyb,prewkeyc,prewkeyd,prewkeyf,prewkeyj)
return
wasd(a,b,c,d,f,j)
{

if(a = 1)
{
FileAppend," ",C:/MyEngine/input_bsig.sig
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_forward.sig
FileDelete,C:/MyEngine/input_sig.sig
}
if(b = 1)
{
FileAppend," ",C:/MyEngine/input_bsig.sig
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_back.sig
FileDelete,C:/MyEngine/input_sig.sig
}
if(c = 1)
{
FileAppend," ",C:/MyEngine/input_bsig.sig
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_right.sig
FileDelete,C:/MyEngine/input_sig.sig
}
if(d = 1)
{
FileAppend," ",C:/MyEngine/input_bsig.sig
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_left.sig
FileDelete,C:/MyEngine/input_sig.sig
}
if(f = 1)
{
FileAppend," ",C:/MyEngine/input_bsig.sig
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_up.sig
FileDelete,C:/MyEngine/input_sig.sig
}
if(j = 1)
{
FileAppend," ",C:/MyEngine/input_bsig.sig
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_down.sig
FileDelete,C:/MyEngine/input_sig.sig
}

}