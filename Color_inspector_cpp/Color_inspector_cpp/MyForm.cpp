#include "MyForm.h"

using namespace System;
using namespace System::Windows::Forms;

[STAThreadAttribute]
void main(array<String^>^ args) 
{
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);

	Colorinspectorcpp::MyForm form;
	Application::Run(% form);
}
