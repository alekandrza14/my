#include "MyForm.h"
#include <iostream>
#include <fstream>
#include <cstdlib>
#include <process.h>
#pragma comment(lib, "Shell32.lib")
#include <Windows.h>
#include <shellapi.h>
//cstdlib

using namespace System;
using namespace System::Windows::Forms;



void file2() {


    char exePath[MAX_PATH];
    GetModuleFileNameA(NULL, exePath, MAX_PATH);

    std::string path(exePath);
    path = path.substr(0, path.find_last_of("\\/"));

    std::string game = path + "\\Data_TestGame\\MyGame.exe";
    std::string work = path + "\\Data_TestGame";

    ShellExecuteA(
        nullptr,
        "open",
        game.c_str(),
        "-f app.xml -c open",
        work.c_str(),
        SW_SHOW
    );

}

[STAThreadAttribute]
void main(array<String^>^ args)
{
	
	file2();
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);

	startupex2::MyForm form;
	
	Application::Run(%form);
}


