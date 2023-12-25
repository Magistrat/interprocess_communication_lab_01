using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        static string dataString;
        static int dataAddress;
        static IntPtr processHandle;
        static string t;
        [DllImport("kernel32.dll")]
        static extern uint GetLastError();
        // REQUIRED CONSTS

        // REQUIRED METHODS
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess
        (int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory
        (int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int
       lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(int hProcess, int
        lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        const int PROCESS_WM_READ = 0x0010;
        const int PROCESS_WM_WRITE = 0x020;

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            Process process = Process.GetProcessesByName("LabRab2")[0];
            processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, process.Id);




        }

        private void button1_Click(object sender, EventArgs e)
        {

            int bytesRead = 0;
            byte[] buffer = new byte[12];

            ReadProcessMemory((int)processHandle, 14925824, buffer, buffer.Length, ref bytesRead);
            string s = Encoding.UTF8.GetString(buffer);
            textBox1.Text = s;


        }

        private void button2_Click(object sender, EventArgs e)
        {


            int bytesWritten = 0;
            byte[] writeBuffer = Encoding.UTF8.GetBytes(textBox1.Text);

            WriteProcessMemory((int)processHandle, 14925824, writeBuffer, writeBuffer.Length, ref bytesWritten);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
