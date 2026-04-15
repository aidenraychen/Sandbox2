
namespace Sandbox
{
    public partial class SelectCanvas : Form
    {
        List<Button> _canvasButtons = new List<Button>();
        const int BUTTON_MIN_WIDTH = 600;
        public SelectCanvas()
        {
            InitializeComponent();
            this.HorizontalScroll.Maximum = 0;
            this.AutoScroll = false;
            this.VerticalScroll.Visible = false;
            this.AutoScroll = true; //seems to cause some lagging when disabling horizontal scroll bar
            this.Resize += onFormResized;
        }

        private void onFormResized(object sender, EventArgs e)
        {
            this.panContainer.Width = this.Width - 250;
            this.panContainer.Height = this.Height - 120;
            foreach (Button btn in _canvasButtons)
            {
                btn.Width = this.panContainer.Width - 60;
                if (btn.Width < BUTTON_MIN_WIDTH)
                {
                    btn.Width = BUTTON_MIN_WIDTH;
                }
            }
        }

        private void onBackButtonClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        public void UpdateCanvasTitles(string canvasUniqueId, string canvasTitle)
        {
            foreach (var btn in _canvasButtons)
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
            SuspendLayout();
            CanvasManager.EnsureLoaded();
            foreach (Button btn in _canvasButtons)
            {
                panContainer.Controls.Remove(btn);
            }
            _canvasButtons.Clear();

            if (CanvasManager.AllCanvas.Any())
            {
                NoCanvasLabel.Visible = false;

                foreach (CanvasData targetCanvas in CanvasManager.AllCanvas)
                {
                    var btnNew = new Button
                    {
                        Size = new Size(this.panContainer.Width - 60, 150),
                        Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        Name = "btnCanvasSelection" + _canvasButtons.Count,
                        Text =  string.IsNullOrEmpty(targetCanvas.CanvasTitle) ? targetCanvas.CanvasUniqueId : targetCanvas.CanvasTitle,
                        Tag = targetCanvas.CanvasUniqueId,

                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance = { BorderSize = 1 },
                        
                        BackColor = Color.LightSkyBlue,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Location = new Point(0, _canvasButtons.Count * 150 + 75),
                        Padding = new Padding(30, 0, 0, 0)
                    };

                    if (btnNew.Width < BUTTON_MIN_WIDTH)
                    {
                        btnNew.Width = BUTTON_MIN_WIDTH;
                    }

                    btnNew.SendToBack();
                    btnNew.MouseClick += onCanvasButtonClick;
                    panContainer.Controls.Add(btnNew);
                    _canvasButtons.Add(btnNew);
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
