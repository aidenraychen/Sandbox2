using System.Text.Json;


namespace Sandbox
{
    public partial class Canvas : Form
    {
        List<Button> _noteButtons = new List<Button>();
        bool isDrag = false;
        private Point offset;
        private Button buttonTarget;
        private SelectCanvas _selectCanvas;
        private string _canvasUniqueId;
        private CanvasData _currentCanvasData;
        private Panel colorPanel;
        bool isPanning = false;
        Point panStartPoint;


        public Canvas()
        {
            InitializeComponent();
            InitializeColorMenu();

            this.panWall.MouseDown += CanvasMouseDown;
            this.panWall.MouseMove += CanvasMouseMove;
            this.panWall.MouseUp += CanvasMouseUp;
        }

        private void CanvasMouseDown(object? sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                isPanning = true;
                panStartPoint = e.Location;
                this.Cursor = Cursors.Hand;
            }
        }

        private void CanvasMouseMove(object? sender, MouseEventArgs e)
        {
            if (isPanning)
            {
                int dx = e.X - panStartPoint.X;
                int dy = e.Y - panStartPoint.Y;
                foreach (Button btn in _noteButtons)
                {
                    btn.Left += dx;
                    btn.Top += dy;
                }
                panStartPoint = e.Location;
            }
        }

        private void CanvasMouseUp(object? sender, MouseEventArgs e)
        {
            if (isPanning)
            {
                isPanning = false;
                this.Cursor = Cursors.Default;
            }
        }
        private void InitializeColorMenu()
        {
            int colorSquareSize = 60;
            colorPanel = new Panel();
            colorPanel.Size = new Size(colorSquareSize * 6 + 62, colorSquareSize + 10);
            colorPanel.BorderStyle = BorderStyle.FixedSingle;
            colorPanel.Location = new Point(120, 120);
            colorPanel.Visible = false;
            Color[] colors = new Color[]
            {
                Color.LightYellow,
                Color.LightBlue,
                Color.LightPink,
                Color.LightGreen,
                Color.PeachPuff,
                Color.LightGray
            };
            int x = 5;
            foreach (var color in colors)
            {
                var colorSquare = new Button();
                colorSquare.BackColor = color;
                colorSquare.AutoSize = false;
                colorSquare.Size = new Size(colorSquareSize, colorSquareSize);
                colorSquare.Margin = Padding.Empty;
                colorSquare.Location = new Point(x, 5);
                colorSquare.MouseClick += onColorSquareClick;
                colorPanel.Controls.Add(colorSquare);
                x += colorSquareSize + 2;
            }
            var exitButton = new Button();
            exitButton.BackColor = Color.Red;
            exitButton.ForeColor = Color.White;
            exitButton.Size = new Size(40, 60);
            exitButton.Location = new Point(5 + colors.Length * (colorSquareSize + 2), 5);
            exitButton.Text = "X";
            exitButton.Font = new Font("Arial", 12);
            exitButton.TextAlign = ContentAlignment.MiddleCenter;
            exitButton.Padding = new Padding(0);
            exitButton.MouseClick += (s, e) => { colorPanel.Visible = false; };
            colorPanel.Controls.Add(exitButton);
            this.Controls.Add(colorPanel);
        }

        public void InitCanvas(SelectCanvas selectCanvas,
            string canvasUniqueId,
            bool isNew)
        {
            if (isNew)
            {
                CanvasData newCanvasData = new CanvasData()
                {
                    CanvasUniqueId = CanvasData.generateCanvasUniqueId(),
                    CanvasTitle = string.Empty, 
                };
                _currentCanvasData = newCanvasData;
                this.Text = "New";
                renameCanvasButton.Enabled = false;

            }
            else
            {
                LoadCanvasData(canvasUniqueId);
                renameCanvasButton.Enabled = true;
            }

            _selectCanvas = selectCanvas;
            _canvasUniqueId = canvasUniqueId;
        }

        private void onColorSquareClick(object? sender, MouseEventArgs e)
        {
            if (sender is Button colorSquare)
            {
                buttonTarget.BackColor = colorSquare.BackColor;
            }
        }

        public void InsertCanvasData() //saves canvas with canvasdata
        {
            if (string.IsNullOrEmpty(_canvasUniqueId))
            {
                if (this.MdiParent is MDISandbox mdi)
                {
                    _canvasUniqueId = CanvasData.generateCanvasUniqueId(); //assigns canvas id from createDateTime
                }
            }

            if (CanvasManager.AllCanvas == null)
            {
                CanvasManager.AllCanvas = new List<CanvasData>();
            }

            var noteData = _noteButtons.Select(b => new NoteData
            {
                Text = b.Text,
                X = b.Location.X,
                Y = b.Location.Y,
                Width = b.Width,
                Height = b.Height,
                BackColor = b.BackColor.ToArgb().ToString("X8"),
            }).ToList();

            _currentCanvasData.Notes = noteData;

            CanvasManager.AllCanvas.Add(_currentCanvasData);

            SaveCanvasData();

            System.Diagnostics.Debug.WriteLine($"Inserting Canvas: {_canvasUniqueId}");
        }


        public void UpdateCanvasData() //saves canvas with canvasdata
        {
            var noteData = _noteButtons.Select(b => new NoteData
            {
                Text = b.Text,
                X = b.Location.X,
                Y = b.Location.Y,
                Width = b.Width,
                Height = b.Height,
                BackColor = b.BackColor.ToArgb().ToString("X8"),
            }).ToList();


            int index = CanvasManager.AllCanvas.FindIndex(c => c.CanvasUniqueId == _canvasUniqueId); //overwrite old data is present, otherwise make new data
            if (index >= 0)
            {
                CanvasManager.AllCanvas[index].CanvasUniqueId = _canvasUniqueId;
                CanvasManager.AllCanvas[index].Notes = noteData;
                CanvasManager.AllCanvas[index].CanvasTitle = _currentCanvasData.CanvasTitle;
            }

            SaveCanvasData();
            System.Diagnostics.Debug.WriteLine($"Updating Canvas: {_canvasUniqueId}");
        }

        private void SaveCanvasData() //saves canvas data to JSON file
        {
            string json = JsonSerializer.Serialize(CanvasManager.AllCanvas, new JsonSerializerOptions { WriteIndented = true });
            string jsonWritePath = System.IO.Path.Combine( 
                AppDomain.CurrentDomain.BaseDirectory,
                "SandboxNotes.json");
            if (File.Exists(jsonWritePath))
            {
                File.WriteAllText(jsonWritePath, json);
            }
            else
            {
                File.WriteAllText(jsonWritePath, "[]"); // create empty JSON file
            }
        }

        public void LoadCanvasData(string canvasUniqueId) //loads canvas data using canvas unique name
        {
            var canvasData = CanvasManager.AllCanvas
                .FirstOrDefault(c => c.CanvasUniqueId == canvasUniqueId);
            if (canvasData == null)
            {
                return;
            }

            // populate to UI
            _canvasUniqueId = canvasData.CanvasUniqueId;
            this.Text = canvasData.CanvasTitle;
            _currentCanvasData = canvasData;

            foreach (var d in canvasData.Notes)
            {
                var noteBtn = new Button
                {
                    Text = d.Text,
                    Location = new Point(d.X, d.Y),
                    Size = new Size(d.Width, d.Height),
                    BackColor = Color.FromArgb(Convert.ToInt32(d.BackColor, 16)),
                };
                noteBtn.MouseDown += onButton_MouseDown;
                noteBtn.MouseMove += onButton_MouseMove;
                noteBtn.MouseUp += onButton_MouseUp;

                panWall.Controls.Add(noteBtn);
                noteBtn.BringToFront();
                _noteButtons.Add(noteBtn);

            }
        }

        public void onCreateNote_Click(object? sender, EventArgs e) //make new note
        {
            var btnNewNote = new Button
            {
                Size = new Size(200, 200),
                Location = new Point(this.Width - 300 - _noteButtons.Count * 10, this.Height / 5 + _noteButtons.Count * 50),
                Name = "btnNew" + _noteButtons.Count,
                Text = "New Note",
                BackColor = Color.LightYellow,
            };

            SuspendLayout();

            btnNewNote.TabIndex = 0;
            btnNewNote.MouseDown += onButton_MouseDown;
            btnNewNote.MouseMove += onButton_MouseMove;
            btnNewNote.MouseUp += onButton_MouseUp;

            panWall.Controls.Add(btnNewNote);

            _noteButtons.Add(btnNewNote);

            ResumeLayout();
        }

        private void onNoteClick(object? sender, MouseEventArgs e) //gets last mouse target
        {
            buttonTarget = (Button)sender;
        }

        private void onButton_MouseDown(object? sender, MouseEventArgs e) //defines mouse actions on notes
        {
            Point screenPos = PointToClient(MousePosition);
            if (e.Button == MouseButtons.Left)
            {
                buttonTarget = (Button)sender;
                offset = e.Location;
                if (screenPos.X - offset.X >= 0 && screenPos.Y - offset.Y + panWall.Top >= 0)
                {
                    isDrag = true;
                }

                buttonTarget.BringToFront();
            }
            if (e.Button == MouseButtons.Right)
            {
                buttonTarget = (Button)sender;
                noteEditMenu.Show(this, new Point(buttonTarget.Right, buttonTarget.Top + panWall.Top));
            }
        }

        private void onButton_MouseMove(object? sender, MouseEventArgs e) //can drag notes
        {
            Point screenPos = PointToClient(MousePosition);
            if (isDrag && buttonTarget != null)
            { 
                var newX = screenPos.X - offset.X;
                var newY = screenPos.Y - offset.Y - panWall.Top;

                buttonTarget.Location = new Point(newX, newY);
            }
        }

        private void onButton_MouseUp(object? sender, MouseEventArgs e) //helps with drag function
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isDrag)
                {
                    isDrag = false;
                }
            }
        }

        public void ShowNoteEditForm(object? sender, EventArgs e) //shows new form to edit note text
        {
            if (this.MdiParent != null)
            {
                NoteEditDialog childForm = new NoteEditDialog(buttonTarget.Text, newText => buttonTarget.Text = newText);
                childForm.StartPosition = FormStartPosition.CenterScreen;
                childForm.WindowState = FormWindowState.Normal;

                childForm.Show(this);
            }

        }

        public void DeleteNote(object? sender, EventArgs e) //delete
        {
            Controls.Remove(buttonTarget);
            _noteButtons.Remove(buttonTarget);
        }

        private void onChooseColorClick(object? sender, MouseEventArgs e) //can choose colors
        {
            colorPanel.BringToFront();
            colorPanel.Visible = true;
        }

        private void onSaveCanvas_Click(object? sender, MouseEventArgs e) //makes select canvas button on Select Canvas once save is clicked
        {
            if (string.IsNullOrEmpty(_canvasUniqueId))
            {
                CanvasNameDialog dialog = new CanvasNameDialog();
                dialog.Text = "Name the new Canvas";
                var tempName = CanvasData.generateCanvasUniqueId();
                dialog.SetCanvasTitle(tempName);
                dialog.StartPosition = FormStartPosition.CenterScreen;

                if (dialog.ShowDialog() == DialogResult.OK) 
                {
                    _currentCanvasData.CanvasTitle = dialog.GetCanvasTitle();
                    InsertCanvasData();
                    this.Text = _currentCanvasData.CanvasTitle;
                    renameCanvasButton.Enabled = true;
                }
            }
            else
            {
                UpdateCanvasData();
            }
        }

        private void onRenameCanvasClick(object? sender, MouseEventArgs e)
        {
            CanvasNameDialog dialog = new CanvasNameDialog();
            dialog.Text = "Rename Canvas";
            dialog.SetCanvasTitle(_currentCanvasData.CanvasTitle);

            dialog.StartPosition = FormStartPosition.CenterScreen;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _currentCanvasData.CanvasTitle = dialog.GetCanvasTitle();
                UpdateCanvasData();
                _selectCanvas.UpdateCanvasTitles(_currentCanvasData.CanvasUniqueId, _currentCanvasData.CanvasTitle);
                
                this.Text = _currentCanvasData.CanvasTitle;
            }
        }

        private void onCloseCanvasClick(object? sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void onDeleteCanvasClick(object? sender, MouseEventArgs e)
        {
            CanvasData targetCanvas = CanvasManager.AllCanvas.FirstOrDefault(c => c.CanvasUniqueId == _canvasUniqueId);
            if (targetCanvas != null)
            {
                CanvasManager.AllCanvas.Remove(targetCanvas);
                SaveCanvasData();
                _selectCanvas.PopulateCanvasSelections();
            }

            this.Close();
        }
    }
}
