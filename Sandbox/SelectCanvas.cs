using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sandbox
{
    public partial class SelectCanvas : Form
    {
        List<Button> buttons = new List<Button>();
        public SelectCanvas()
        {
            InitializeComponent();
        }

        private void OnBackButtonClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }
        public void createCanvasSelections(int formNum) //creates a gray rectangle with canvas name for each new canvas saved
        {
            if(buttons.Any(b=>b.Tag is int tag && tag == formNum))
            {
                return;
            }
            var btnNew = new Button
            {
                Size = new Size(ClientRectangle.Width - 150, 150),

                Name = "btnNew" + buttons.Count,

                Text = $"New Note {formNum-1}",

                //BackColor = Color.Gray,

                Location = new Point(150, buttons.Count * 150 + 75),

                Tag = formNum
            };
            Controls.Add(btnNew);
            buttons.Add(btnNew);
            btnNew.SendToBack();
            btnNew.MouseClick += onCanvasButtonClick;
        }

        private void onCanvasButtonClick(object sender, MouseEventArgs e) //opens saved canvas once button clicked
        {
            var btnTarget = (Button)sender;
            System.Diagnostics.Debug.WriteLine($"Button Tag: {btnTarget.Tag}");
            if (btnTarget != null && btnTarget.Tag is int indexNum)
            {
                frmCanvas canvasToBeOpened = new frmCanvas(this, indexNum);
                canvasToBeOpened.MdiParent = this.MdiParent;
                canvasToBeOpened.restoreCanvas(indexNum);
                canvasToBeOpened.Show();
                this.Hide();
            }
        }
        //link the button to opening the form
    }
}
