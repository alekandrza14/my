FileCreateDir, "C:/MyEngine"
prewkey = "";




Up::
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_forward.sig
FileDelete,C:/MyEngine/input_sig.sig
prewkey = "w";
return


Down::
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_back.sig
FileDelete,C:/MyEngine/input_sig.sig
prewkey = "s";
return

Right::
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_right.sig
FileDelete,C:/MyEngine/input_sig.sig
prewkey = "d";
return

Left::
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_left.sig
FileDelete,C:/MyEngine/input_sig.sig
prewkey = "a";
return

e::
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend," ",C:/MyEngine/input_up.sig
FileDelete,C:/MyEngine/input_sig.sig
prewkey = "e";
return

q:: 
FileAppend," ",C:/MyEngine/input_sig.sig
FileAppend,"",C:/MyEngine/input_down.sig
FileDelete,C:/MyEngine/input_sig.sig
prewkey = "q";
return