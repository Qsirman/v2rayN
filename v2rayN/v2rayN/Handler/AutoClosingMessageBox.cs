﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace v2rayN.Handler
{

    public partial class AutoClosingMessageBox:Form
    {
        
        System.Threading.Timer _timeoutTimer;
        string _caption;
        AutoClosingMessageBox(string msg)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.label1.Text = msg;
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, 1000, System.Threading.Timeout.Infinite);

            using (_timeoutTimer)
                show();
        }
        public static void Show(string text, string caption, int timeout)
        {
            new AutoClosingMessageBox(text);
        }
        void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
            if (mbWnd != IntPtr.Zero)
                SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            _timeoutTimer.Dispose();
        }
        const int WM_CLOSE = 0x0010;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    }
}