namespace Sandbox
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            this.FormClosing += HomePage_FormClosing;
            this.Load += HomePage_Load;
        }
        private void ShowNewForm(object sender, EventArgs e) //creates new form
        {
            if (this.MdiParent is MDISandbox mdiParent)
            {
                mdiParent.ShowNewForm(sender, e);
                this.Close();
            }
        }

        private void OpenFile(object sender, EventArgs e)  //opens existing form
        {
            if (this.MdiParent is MDISandbox mdiParent)
            {
                mdiParent.OpenFile(sender, e);
                this.Close();
            }
        }

        private void HomePage_Load(object sender, EventArgs e) //draws horizontal lines for homepage aesthetic.
        {
            for (int i = 1; i < 4; i++)
            {
                Panel horizontalLine = new Panel
                {
                    BackColor = Color.Black,
                    Height = 1,
                    Width = 12000,
                    Location = new Point(0, i * 150 + 75),

                };
                Controls.Add(horizontalLine);
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
