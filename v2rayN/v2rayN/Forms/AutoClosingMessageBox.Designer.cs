using System.Windows.Forms;
using System;
using System.Threading;

namespace v2rayN.Forms
{
    partial class AutoClosingMessageBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        static System.Threading.Timer _timeoutTimer;
        public AutoClosingMessageBox(string msg)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.label1.Text = msg;
            //this.
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, 3000, 1000);
            this.StartPosition = FormStartPosition.CenterScreen;
            using (_timeoutTimer)
            //_timeoutTimer.run();
            Show();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void OnTimerElapsed(object state)
        {
            //IntPtr mbWnd = FindWindow("#32770", "msg"); // lpClassName is #32770 for MessageBox
            //if (mbWnd != IntPtr.Zero)
            //SendMessage(this.Handle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            _timeoutTimer.Dispose();
            this.Dispose();
            
        }
        static public void show(string msg)
        {
            new AutoClosingMessageBox(msg);
            
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // AutoClosingMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 127);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "AutoClosingMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "msg";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        
        private System.Windows.Forms.Label label1;
    }
}