#pragma once
#include <fstream>
#include <msclr\marshal.h>
#include <msclr\marshal_cppstd.h>
#include <cstdio>;

using namespace msclr::interop;

namespace Colorinspectorcpp {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// —водка дл€ MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	private:
		String^ json;
	private:
		int^ c1; 
	private:
		int^ c2;
	private: System::Windows::Forms::Label^ label1;

	private:
		int^ c3;
	public:
		MyForm(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
			
		}

	protected:
		/// <summary>
		/// ќсвободить все используемые ресурсы.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	internal: System::Windows::Forms::Panel^ panel1;
	protected:

	protected:

	protected:
	private: System::Windows::Forms::TrackBar^ trackBar1;
	private: System::Windows::Forms::TrackBar^ trackBar2;
	private: System::Windows::Forms::TrackBar^ trackBar3;
		   
	private:
		/// <summary>
		/// ќб€зательна€ переменна€ конструктора.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// “ребуемый метод дл€ поддержки конструктора Ч не измен€йте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^ resources = (gcnew System::ComponentModel::ComponentResourceManager(MyForm::typeid));
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->trackBar1 = (gcnew System::Windows::Forms::TrackBar());
			this->trackBar2 = (gcnew System::Windows::Forms::TrackBar());
			this->trackBar3 = (gcnew System::Windows::Forms::TrackBar());
			this->label1 = (gcnew System::Windows::Forms::Label());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar1))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar2))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar3))->BeginInit();
			this->SuspendLayout();
			// 
			// panel1
			// 
			this->panel1->BackColor = System::Drawing::Color::Black;
			this->panel1->Cursor = System::Windows::Forms::Cursors::Hand;
			this->panel1->Location = System::Drawing::Point(12, 12);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(294, 282);
			this->panel1->TabIndex = 0;
			this->panel1->BackColorChanged += gcnew System::EventHandler(this, &MyForm::panel1_BackColorChanged);
			this->panel1->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &MyForm::panel1_Paint);
			// 
			// trackBar1
			// 
			this->trackBar1->Location = System::Drawing::Point(12, 332);
			this->trackBar1->Maximum = 255;
			this->trackBar1->Name = L"trackBar1";
			this->trackBar1->Size = System::Drawing::Size(104, 45);
			this->trackBar1->TabIndex = 1;
			this->trackBar1->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &MyForm::trackBar1_KeyDown);
			this->trackBar1->KeyUp += gcnew System::Windows::Forms::KeyEventHandler(this, &MyForm::trackBar1_KeyUp);
			this->trackBar1->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &MyForm::trackBar1_MouseDown);
			this->trackBar1->MouseUp += gcnew System::Windows::Forms::MouseEventHandler(this, &MyForm::trackBar1_MouseUp);
			// 
			// trackBar2
			// 
			this->trackBar2->Location = System::Drawing::Point(112, 332);
			this->trackBar2->Maximum = 255;
			this->trackBar2->Name = L"trackBar2";
			this->trackBar2->Size = System::Drawing::Size(104, 45);
			this->trackBar2->TabIndex = 2;
			this->trackBar2->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &MyForm::trackBar2_KeyDown);
			this->trackBar2->KeyUp += gcnew System::Windows::Forms::KeyEventHandler(this, &MyForm::trackBar2_KeyUp);
			this->trackBar2->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &MyForm::trackBar2_MouseDown);
			this->trackBar2->MouseUp += gcnew System::Windows::Forms::MouseEventHandler(this, &MyForm::trackBar2_MouseUp);
			// 
			// trackBar3
			// 
			this->trackBar3->Location = System::Drawing::Point(211, 332);
			this->trackBar3->Maximum = 255;
			this->trackBar3->Name = L"trackBar3";
			this->trackBar3->Size = System::Drawing::Size(104, 45);
			this->trackBar3->TabIndex = 3;
			this->trackBar3->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &MyForm::trackBar3_KeyDown);
			this->trackBar3->KeyUp += gcnew System::Windows::Forms::KeyEventHandler(this, &MyForm::trackBar3_KeyUp);
			this->trackBar3->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &MyForm::trackBar3_MouseDown);
			this->trackBar3->MouseUp += gcnew System::Windows::Forms::MouseEventHandler(this, &MyForm::trackBar3_MouseUp);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->ForeColor = System::Drawing::Color::White;
			this->label1->Location = System::Drawing::Point(30, 301);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(35, 13);
			this->label1->TabIndex = 4;
			this->label1->Text = L"label1";
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::Black;
			this->ClientSize = System::Drawing::Size(318, 376);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->trackBar3);
			this->Controls->Add(this->trackBar2);
			this->Controls->Add(this->trackBar1);
			this->Controls->Add(this->panel1);
			this->Cursor = System::Windows::Forms::Cursors::Hand;
			this->Icon = (cli::safe_cast<System::Drawing::Icon^>(resources->GetObject(L"$this.Icon")));
			this->MaximumSize = System::Drawing::Size(334, 415);
			this->MinimumSize = System::Drawing::Size(334, 415);
			this->Name = L"MyForm";
			this->Text = L"colorinspector";
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar1))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar2))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar3))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void trackBar1_KeyDown(System::Object^ sender, System::Windows::Forms::KeyEventArgs^ e) {
		c3 = trackBar1->Value;
		c2 = trackBar2->Value;
		c1 = trackBar3->Value;
		json = "{\"color1\":" + c1 + ",\"color2\":" + c2 + ",\"color3\":" + c3 + "}";
		label1->Text = json;
		

		this->panel1->BackColor = this->panel1->BackColor.FromArgb(255, (int)c1, (int)c2, (int)c3);
		load();
	}
	private: System::Void trackBar1_KeyUp(System::Object^ sender, System::Windows::Forms::KeyEventArgs^ e) {
		c3 = trackBar1->Value;
		c2 = trackBar2->Value;
		c1 = trackBar3->Value;
		json = "{\"color1\":" + c1 + ",\"color2\":" + c2 + ",\"color3\":" + c3 + "}";
		label1->Text = json;
		this->panel1->BackColor = this->panel1->BackColor.FromArgb(255, (int)c1, (int)c2, (int)c3);
		load();
	}
	private: System::Void trackBar2_KeyDown(System::Object^ sender, System::Windows::Forms::KeyEventArgs^ e) {
		c3 = trackBar1->Value;
		c2 = trackBar2->Value;
		c1 = trackBar3->Value;
		json = "{\"color1\":" + c1 + ",\"color2\":" + c2 + ",\"color3\":" + c3 + "}";
		label1->Text = json;
		this->panel1->BackColor = this->panel1->BackColor.FromArgb(255, (int)c1, (int)c2, (int)c3);
		load();
	}
	private: System::Void trackBar2_KeyUp(System::Object^ sender, System::Windows::Forms::KeyEventArgs^ e) {
		c3 = trackBar1->Value;
		c2 = trackBar2->Value;
		c3 = trackBar3->Value;
		json = "{\"color1\":" + c1 + ",\"color2\":" + c2 + ",\"color3\":" + c3 + "}";
		label1->Text = json;
		this->panel1->BackColor = this->panel1->BackColor.FromArgb(255, (int)c1, (int)c2, (int)c3);
		load();
	}
	private: System::Void trackBar3_KeyDown(System::Object^ sender, System::Windows::Forms::KeyEventArgs^ e) {
		c3 = trackBar1->Value;
		c2 = trackBar2->Value;
		c1 = trackBar3->Value;
		json = "{\"color1\":" + c1 + ",\"color2\":" + c2 + ",\"color3\":" + c3 + "}";
		label1->Text = json;
		this->panel1->BackColor = this->panel1->BackColor.FromArgb(255, (int)c1, (int)c2, (int)c3);
		load();
	}
	private: System::Void trackBar3_KeyUp(System::Object^ sender, System::Windows::Forms::KeyEventArgs^ e) {
		c3 = trackBar1->Value;
		c2 = trackBar2->Value;
		c1 = trackBar3->Value;
		json = "{\"color1\":" + c1 + ",\"color2\":" + c2 + ",\"color3\":" + c3 + "}";
		label1->Text = json;
		this->panel1->BackColor = this->panel1->BackColor.FromArgb(255, (int)c1, (int)c2, (int)c3);
		load();
	}
	private: System::Void panel1_Paint(System::Object^ sender, System::Windows::Forms::PaintEventArgs^ e) {
		
		
	}
private: System::Void trackBar1_MouseDown(System::Object^ sender, System::Windows::Forms::MouseEventArgs^ e) {
	c3 = trackBar1->Value;
	c2 = trackBar2->Value;
	c1 = trackBar3->Value; 
	json = "{\"color1\":" + c1 + ",\"color2\":" + c2 + ",\"color3\":" + c3 + "}";
	label1->Text = json;
	this->panel1->BackColor = this->panel1->BackColor.FromArgb(255, (int)c1, (int)c2, (int)c3);
	load();
}
private: System::Void trackBar1_MouseUp(System::Object^ sender, System::Windows::Forms::MouseEventArgs^ e) {
	c3 = trackBar1->Value;
	c2 = trackBar2->Value;
	c1 = trackBar3->Value;
	json = "{\"color1\":" + c1 + ",\"color2\":" + c2 + ",\"color3\":" + c3 + "}";
	label1->Text = json;
	this->panel1->BackColor = this->panel1->BackColor.FromArgb(255, (int)c1, (int)c2, (int)c3);
	load();
}
private: System::Void trackBar2_MouseDown(System::Object^ sender, System::Windows::Forms::MouseEventArgs^ e) {
	c3 = trackBar1->Value;
	c2 = trackBar2->Value;
	c1 = trackBar3->Value;
	json = "{\"color1\":" + c1 + ",\"color2\":" + c2 + ",\"color3\":" + c3 + "}";
	label1->Text = json;
	this->panel1->BackColor = this->panel1->BackColor.FromArgb(255, (int)c1, (int)c2, (int)c3);
	load();
}
private: System::Void trackBar2_MouseUp(System::Object^ sender, System::Windows::Forms::MouseEventArgs^ e) {
	c3 = trackBar1->Value;
	c2 = trackBar2->Value;
	c1 = trackBar3->Value;
	json = "{\"color1\":" + c1 + ",\"color2\":" + c2 + ",\"color3\":" + c3 + "}";
	label1->Text = json;
	Color c;

	this->panel1->BackColor = this->panel1->BackColor.FromArgb(255, (int)c1, (int)c2, (int)c3);
	load();
}
private: System::Void trackBar3_MouseDown(System::Object^ sender, System::Windows::Forms::MouseEventArgs^ e) {
	c3 = trackBar1->Value;
	c2 = trackBar2->Value;
	c1 = trackBar3->Value;
	json = "{\"color1\":" + c1 + ",\"color2\":" + c2 + ",\"color3\":" + c3 + "}";

	label1->Text = json;
	this->panel1->BackColor = this->panel1->BackColor.FromArgb(255, (int)c1, (int)c2, (int)c3);
	

	
	load();
}
private: System::Void trackBar3_MouseUp(System::Object^ sender, System::Windows::Forms::MouseEventArgs^ e) {
	c3 = trackBar1->Value;
	c2 = trackBar2->Value;
	c1 = trackBar3->Value;
	json = "{\"color1\":" + c1 + ",\"color2\":" + c2 + ",\"color3\":" + c3 + "}";
	label1->Text = json;
	this->panel1->BackColor =	this->panel1->BackColor.FromArgb(255, (int)c1, (int)c2, (int)c3);
	load();
	
	
}
private: System::Void load() {
	
	std::ofstream fount;
	std::ofstream fount2;
	std::fstream fount3;
	std::string path = "C:/MyEngine/color.json";
	std::string path2 = "C:/MyEngine/color_Inspector.sig";
	std::string c = ConvertToASCII(json);
	fount2.open(path2); 

	fount.open(path);
	if (fount.is_open()) {
		fount << c;
	}
	fount2.close();
	remove(path2.c_str());
}
private: System::Void panel1_BackColorChanged(System::Object^ sender, System::EventArgs^ e) {
	
	Panel^ p = (Panel^)sender;
	p->BackColor = p->BackColor.FromArgb(255, (int)c1, (int)c2, (int)c3);
	

}
	   std::string ConvertToASCII(System::String^ _str)
	   {
		   if (_str == nullptr)
			   return std::string();

		   // Creating ASCII encoding (or smth. else)
		   System::Text::ASCIIEncoding^ enc = gcnew System::Text::ASCIIEncoding;

		   // Encoding source string
		   array<unsigned char>^ encodedBytes = enc->GetBytes(_str);
		   if (encodedBytes->Length == 0)
			   return std::string();

		   // Creating std::string
		   pin_ptr<unsigned char> pin(&encodedBytes[0]);
		   char* cstr(reinterpret_cast<char*>(static_cast<unsigned char*>(pin)));
		   return std::string(cstr, encodedBytes->Length);
	   }
};
}
