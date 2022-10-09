#include <windows.h>

LRESULT CALLBACK PROCZZZ(HWND hwnd, UINT INTT, WPARAM wpr, LPARAM lpr);
WNDCLASS newwindowclass(HBRUSH hdr, HCURSOR hcur, HINSTANCE inst, HICON ico, LPCWSTR NAME, WNDPROC wndproc);

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR args, int ncmdshow) {
	HBRUSH t = (HBRUSH)DC_BRUSH;
	
	
	WNDCLASS WIND = newwindowclass(t,LoadCursor(NULL,IDC_ARROW),hInst,LoadIcon(NULL,IDI_QUESTION),
		L"MyEngine_color_inspector", PROCZZZ);
	if (!RegisterClassW(&WIND)) { return -1; }
	
	MSG MESAJ = { 0 };

	CreateWindow(L"MyEngine_color_inspector", L"First c++ window",WS_OVERLAPPEDWINDOW|WS_VISIBLE,
		100,100, 600, 500, NULL, NULL, NULL, NULL );
	
	while (GetMessage(&MESAJ, NULL, NULL, NULL))
	{
		TranslateMessage(&MESAJ);
		DispatchMessage(&MESAJ);
	}
	return 0;
}

WNDCLASS newwindowclass(HBRUSH hdr,HCURSOR hcur,HINSTANCE inst,HICON ico,LPCWSTR NAME,WNDPROC wndproc) {
	WNDCLASS NWC = { 0 };
	NWC.hCursor = hcur;
	NWC.hInstance = inst;
	NWC.hbrBackground = hdr;
	NWC.hIcon = ico;
	NWC.lpszClassName = NAME;
	NWC.lpfnWndProc = wndproc;
	return NWC;
}
LRESULT CALLBACK PROCZZZ(HWND hwnd,UINT INTT,WPARAM wpr,LPARAM lpr) {
	switch (INTT)
	{
	
	case WM_CREATE:
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
			break;
	default: return DefWindowProc(hwnd, INTT, wpr, lpr);
	}
}