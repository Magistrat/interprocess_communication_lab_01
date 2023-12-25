using System;
using System.Runtime.InteropServices;


internal class Program {

    // Определение библиотеки DLL, содержащей функцию SendMessage
    [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
    public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

    // Определение функции блокировки окна
    [DllImport("user32.dll")]
    static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

    // Определение функции поиска окна
    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    // Определение сообщения для закрытия окна
    const int WM_CLOSE = 0x0010;

    // Определение названия окна
    const string WINDOW_FOR = "Maps";

    private static int Main(string[] args)
    {
        Console.WriteLine("For block " + WINDOW_FOR + " press to Enter...");
        Console.ReadLine();

        IntPtr hWnd = FindWindow(null, WINDOW_FOR);

        Console.WriteLine("Blocking a program...");
        EnableWindow(hWnd, false);

        Console.WriteLine("For close " + WINDOW_FOR + " press to Enter...");
        Console.ReadLine();
        SendMessage(hWnd, WM_CLOSE, 0, 0);
        return 0;
    }
}