
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

        private void onBackButtonClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        public void UpdateCanvasTitles(string canvasUniqueId, string canvasTitle)
        {
            foreach (var btn in buttons)
            {
                if (btn.Tag is string tag && tag == canvasUniqueId)
                {
                    btn.Text = canvasTitle;
                    break;
                }
            }
        }


        public void PopulateCanvasSelections() //creates a rectangle with canvas name for each new canvas saved
        {
            foreach (Button b in buttons)
            {
                Controls.Remove(b);
            }
            buttons.Clear();
            if (CanvasManager.AllCanvas.Any())
            {
                NoCanvasLabel.Visible = false;

                foreach (CanvasData targetCanvas in CanvasManager.AllCanvas)
                {
                    var btnNew = new Button
                    {
                        Size = new Size(1000, 100),

                        Name = "btnCanvasSelection" + buttons.Count,
                        Text = string.IsNullOrEmpty(targetCanvas.CanvasTitle) ? targetCanvas.CanvasUniqueId : targetCanvas.CanvasTitle,
                        Tag = targetCanvas.CanvasUniqueId,

                        FlatStyle = FlatStyle.Standard,
                        FlatAppearance = { BorderSize = 0 },
                        BackColor = Color.LightSkyBlue,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Location = new Point(350, buttons.Count * 150 + 75),
                        Padding = new Padding(30, 0, 0, 0)
                    };

                    btnNew.SendToBack();
                    btnNew.MouseClick += onCanvasButtonClick;
                    Controls.Add(btnNew);
                    buttons.Add(btnNew);
                }
            }
            else 
            { 
                NoCanvasLabel.Visible = true;
            }
        }

        public void DeleteCanvas(string canvasUniqueId)
        {
            CanvasData targetCanvas = CanvasManager.AllCanvas.FirstOrDefault(c => c.CanvasUniqueId == canvasUniqueId);
            if (targetCanvas != null)
            {
                CanvasManager.AllCanvas.Remove(targetCanvas);
            }
        }

        private void onCanvasButtonClick(object sender, MouseEventArgs e) //opens saved canvas once button clicked
        {
            var btnTarget = (Button)sender;
            System.Diagnostics.Debug.WriteLine($"Button Tag: {btnTarget.Tag}");
            if (btnTarget != null && btnTarget.Tag is string canvasUniqueId)
            {
                CanvasManager.EnsureLoaded();

                Canvas canvasToBeOpened = new Canvas();
                canvasToBeOpened.MdiParent = this.MdiParent;
                canvasToBeOpened.InitCanvas(this, canvasUniqueId, false);
                canvasToBeOpened.Show();
                canvasToBeOpened.BringToFront();
                canvasToBeOpened.TopMost = true;
                canvasToBeOpened.WindowState = FormWindowState.Maximized;

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
