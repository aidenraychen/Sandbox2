using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Sandbox
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            this.FormClosing += HomePage_FormClosing;
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            if (this.MdiParent is MDISandbox mdiParent)
            {
                mdiParent.ShowNewForm(sender, e);
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            if (this.MdiParent is MDISandbox mdiParent)
            {
                mdiParent.OpenFile(sender, e);
            }
        }

        private void HomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) 
            {
                e.Cancel = true;
            }
            
        }
    }
}
