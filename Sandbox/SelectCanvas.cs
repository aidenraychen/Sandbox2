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
            this.HorizontalScroll.Maximum = 0;
            this.AutoScroll = false;
            this.VerticalScroll.Visible = false;
            this.AutoScroll = true; //seems to cause some lagging when disabling horizontal scroll bar
        }

        private void OnBackButtonClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        public void updateCanvasNames(int canvasNum, String canvasName)
        {
            foreach (var btn in buttons)
            {
                if (btn.Tag is int tag && tag == canvasNum+1)
                {
                    btn.Text = canvasName;
                    break;
                }
            }
        }
        public void createCanvasSelections(int formNum) //creates a gray rectangle with canvas name for each new canvas saved
        {
            if(buttons.Any(b=>b.Tag is int tag && tag == formNum))
            {
                return;
            }
            Panel horizontalLine = new Panel
            {
                BackColor = Color.Black,
                Height = 1,
                Width = 12000,
                Location = new Point(150,buttons.Count * 150 + 75),
            };
            var btnNew = new Button
            {
                Size = new Size(12000, 150),

                Name = "btnNew" + buttons.Count,

                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                //BackColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(150, buttons.Count * 150 + 75),
                Padding = new Padding(30, 0, 0, 0),

                Tag = formNum
            };
            CanvasData targetCanvas = CanvasManager.AllCanvas.FirstOrDefault(c => c.CanvasNum == formNum);

            if (targetCanvas != null && !string.IsNullOrWhiteSpace(targetCanvas.CanvasName))
            {
                btnNew.Text = targetCanvas.CanvasName;
            }
            else
            {
                btnNew.Text = $"New Note {formNum}";
            }
            Controls.Add(btnNew);
            Controls.Add(horizontalLine);
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
                CanvasManager.EnsureLoaded();
                CanvasData targetCanvas = CanvasManager.AllCanvas.FirstOrDefault(c => c.CanvasNum == indexNum);
                frmCanvas canvasToBeOpened = new frmCanvas(this, indexNum, targetCanvas);
                canvasToBeOpened.MdiParent = this.MdiParent;
                canvasToBeOpened.restoreCanvas(indexNum);
                canvasToBeOpened.Show();
                this.Hide();
            }
        }
        //link the button to opening the form
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Cancel user/Mdi-initiated closes so the instance is not disposed
            if (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.MdiFormClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                base.OnFormClosing(e);
            }
        }
    }
}
