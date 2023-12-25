using System;
using System.Runtime.InteropServices;


internal class Program {

    // определение библиотеки DLL, содержащей фунецию SM
    [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
    // Инициализация функции SM (дескриптор окна, тип сообщения, дополнительная информация о сообщении, доп информация)
    public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
    [DllImport("user32.dll")]

    // блокировка окна запущенного приложения
    static extern bool EnableWindow(IntPtr hWnd, bool bEnable);
    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


    private static int Main(string[] args)
    {
        IntPtr hWnd = FindWindow(null, "Calendar");
        EnableWindow(hWnd, false);
        return 0;
    }
}