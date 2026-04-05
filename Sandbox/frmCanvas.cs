using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Windows.Forms;
using Windows.Gaming.Input.ForceFeedback;
using Windows.Graphics.Printing.Workflow;
using Windows.Storage;
using static Sandbox.frmCanvas;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Sandbox
{
    //private readonly SelectCanvas _selectCanvas;
    public partial class frmCanvas : Form
    {
        List<Button> buttons = new List<Button>();
        bool isDrag = false;
        private Point offset;
        private Button buttonTarget;
        bool mouseDown = false;
        private Stopwatch dblClickTimer = new Stopwatch();
        private SelectCanvas _selectCanvas;
        private int _formNum;
        private Panel colorPanel;
        private Panel renamePanel;
        private TextBox renameTextBox;
        private Button renameCanvasSaveButton;
        private Button renameCanvasCancelButton;
        private CanvasData currentCanvas;

        public frmCanvas(SelectCanvas sCanvas, int childFormNumber)
        {
            InitializeComponent();
            InitializeColorMenu();
            InitializeRenamePanel();
            _selectCanvas = sCanvas; //import this so that we can make changes on Select Canvas from actions done here (make new select canvas button upon new canvas save)
            string path = Path.Combine( //dynamically get path to file
                AppDomain.CurrentDomain.BaseDirectory,
                "SandboxNotes.json"
            );
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "[]"); // create empty JSON file //it doesnt create the file for some reason
            }
        }
        private void InitializeColorMenu()
        {
            int colorSquareSize = 60;
            colorPanel = new Panel();
            colorPanel.Size = new Size(colorSquareSize*6+62, colorSquareSize+10);
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
                x += colorSquareSize+2;
            }
            var exitButton = new Button();
            exitButton.BackColor = Color.Red;
            exitButton.ForeColor = Color.White;
            exitButton.Size = new Size(40, 60);
            exitButton.Location = new Point (5 + colors.Length * (colorSquareSize + 2), 5);
            exitButton.Text = "X";      
            exitButton.Font = new Font("Arial", 12);
            exitButton.TextAlign = ContentAlignment.MiddleCenter;
            exitButton.Padding = new Padding(0);
            exitButton.MouseClick += (s, e) => { colorPanel.Visible = false; };
            colorPanel.Controls.Add(exitButton);
            this.Controls.Add(colorPanel);
        }
        private void InitializeRenamePanel()
        {
            renameCanvasSaveButton = new Button();
            renameCanvasSaveButton.Location = new Point(25, 50);
            renameCanvasSaveButton.Size = new Size(80, 30);
            renameCanvasSaveButton.Text = "Save";
            renameCanvasSaveButton.MouseClick += onRenameCanvasSaveButtonClick;

            renameCanvasCancelButton = new Button();
            renameCanvasCancelButton.Location = new Point(135, 50);
            renameCanvasCancelButton.Size = new Size(80, 30);
            renameCanvasCancelButton.Text = "Cancel";
            renameCanvasSaveButton.MouseClick += onRenameCanvasCancelButton;

            renamePanel = new Panel();
            renamePanel.Size = new Size(250, 100);
            renamePanel.Visible = false;
            renamePanel.BackColor = Color.White;

            renameTextBox = new TextBox();
            renameTextBox.Size = new Size(200, 25);
            renameTextBox.Location = new Point(25, 10);

            renamePanel.Controls.Add(renameTextBox);
            renamePanel.Controls.Add(renameCanvasSaveButton);
            renamePanel.Controls.Add(renameCanvasCancelButton);

            this.Controls.Add(renamePanel);
            renamePanel.BringToFront();
        }

        private void onRenameCanvasCancelButton(object sender, MouseEventArgs e)
        {
            renamePanel.Visible = false;
        }

        private void onRenameCanvasSaveButtonClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(renameTextBox.Text))
            {
                currentCanvas.CanvasName = renameTextBox.Text;
                renamePanel.Visible = false;
            }
        }
        private void onColorSquareClick(Object sender, MouseEventArgs e)
        {
            if (sender is Button colorSquare)
            {
                buttonTarget.BackColor = colorSquare.BackColor;
            }
            //colorPanel.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        { 

        }
        public class NoteData //defines data for each note
        {
            public string Text { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public string BackColor { get; set; }
        }

        public class CanvasData //defines data for each canvas (canvas num and list of notes)
        {
            public int CanvasNum { get; set; }
            public String CanvasName { get; set; }
            public List<NoteData> Notes { get; set; }
        }


        public void saveCanvas() //saves canvas with canvasdata
        {
            if (_formNum == 0)
            {
                if(this.MdiParent is MDISandbox mdi)
                {
                    _formNum = mdi.getNextCanvasNumber(); //assigns canvas number if new canvas (formnum = 0)
                }
            }
            List<CanvasData> allCanvas = new List<CanvasData>();
            //string path = @"C:\Users\Aiden\source\repos\Sandbox\SandboxNotes.json";
            string path = Path.Combine( //dynamically get path to file
                AppDomain.CurrentDomain.BaseDirectory,
                "SandboxNotes.json"
            );
            string existingJson = File.ReadAllText(path);
            allCanvas = JsonSerializer.Deserialize<List<CanvasData>>(existingJson);
            if (allCanvas == null)
            {
                allCanvas = new List<CanvasData>();
            }
            var data = buttons.Select(b => new NoteData
            {
                Text = b.Text,
                X = b.Location.X,
                Y = b.Location.Y,
                Width = b.Width,
                Height = b.Height,
                BackColor = b.BackColor.ToArgb().ToString("X8"),
            }).ToList();
            var canvasData = new CanvasData
            {
                CanvasNum = _formNum,
                Notes = data
            };

            int index = allCanvas.FindIndex(c => c.CanvasNum == _formNum); //overwrite old data is present, otherwise make new data
            if (index >= 0)
            {
                allCanvas[index]= canvasData;
            }
            else
            {
                allCanvas.Add(canvasData);
            }
            string json = JsonSerializer.Serialize(allCanvas, new JsonSerializerOptions { WriteIndented = true });
            string jsonWritePath = Path.Combine( //dynamically get path to file
                AppDomain.CurrentDomain.BaseDirectory,
                "SandboxNotes.json"
            );
            File.WriteAllText(jsonWritePath, json);
            
            System.Diagnostics.Debug.WriteLine($"Saving Canvas Number: {_formNum}");
        }


        public void restoreCanvas(int formNum) //loads canvas data using form num
        {
            // string path = @"C:\Users\Aiden\source\repos\Sandbox\SandboxNotes.json";
            //if (File.Exists(path)) return;
            string path = Path.Combine( 
                AppDomain.CurrentDomain.BaseDirectory,
                "SandboxNotes.json"
            );
            //if (!File.Exists(path))
            //{
            //    File.WriteAllText(path, "[]"); // create empty JSON file
            //}
            string json = File.ReadAllText(path);
            var allCanvas = JsonSerializer.Deserialize<List<CanvasData>>(json);
            if(allCanvas == null)
            {
                return;
            }
            var canvasData = allCanvas.FirstOrDefault(c =>  c.CanvasNum == formNum);
            if (canvasData == null)
            {
                return;
            }
            _formNum = canvasData.CanvasNum;
            foreach (var d in canvasData.Notes)
            {
                var newBtn = new Button
                {
                    Text = d.Text,
                    Location = new Point(d.X, d.Y),
                    Size = new Size(d.Width, d.Height),
                    BackColor = Color.FromArgb(Convert.ToInt32(d.BackColor, 16)),
                };
                newBtn.MouseDown += OnButton_MouseDown;
                newBtn.MouseMove += OnButton_MouseMove;
                newBtn.MouseUp += OnButton_MouseUp;

                Controls.Add(newBtn);
                buttons.Add(newBtn);

            }
        }
        private void onSaveButton_Click(object sender, MouseEventArgs e) //makes select canvas button on Select Canvas once save is clicked
        {
            saveCanvas();
            _selectCanvas.createCanvasSelections(_formNum);
        }
        public void onCreateNote_Click(object sender, EventArgs e) //make new note
        {
            var btnNew = new Button
            {
                Size = new Size(200, 200),
                
                Name = "btnNew" + buttons.Count,

                Text = "New Note",

                BackColor = Color.LightYellow,
            };
            Random rnd = new Random();
            btnNew.Location = new Point(rnd.Next(25, this.ClientSize.Width - 25), rnd.Next(112, this.ClientSize.Height - 25));
            //SuspendLayout();


            btnNew.TabIndex = 0;
            btnNew.MouseDown += OnButton_MouseDown;
            btnNew.MouseMove += OnButton_MouseMove;
            btnNew.MouseUp += OnButton_MouseUp;
            string path = Path.Combine( //dynamically get path to file
                AppDomain.CurrentDomain.BaseDirectory,
                "SandboxNoteText.txt"
            );
            string noteText = path;
            Controls.Add(btnNew);

            buttons.Add(btnNew);
            //ResumeLayout();

        }

        private void onNoteClick (object sender, MouseEventArgs e) //gets last mouse target
        {
            buttonTarget = (Button)sender;
        }

        private void OnButton_MouseDown(object sender, MouseEventArgs e) //defines mouse actions on notes
        {
            Point screenPos = PointToClient(MousePosition);
            if (e.Button == MouseButtons.Left)
            {
                buttonTarget = (Button)sender;
                offset = e.Location;
                if (screenPos.X - offset.X >=0 && screenPos.Y - offset.Y>=0)
                {
                    isDrag = true;
                }

                mouseDown = true;
                buttonTarget.BringToFront();
            }
            if (e.Button == MouseButtons.Right)
            {
                buttonTarget = (Button)sender;
                noteEditMenu.Show(this, new Point(buttonTarget.Right, buttonTarget.Top));
            }
        }

        private void OnButton_MouseMove(object sender, MouseEventArgs e) //can drag notes
        {
            Point screenPos = PointToClient(MousePosition);
            if (isDrag && buttonTarget != null)
            {
                buttonTarget.Location = new Point(
                    screenPos.X - offset.X,
                    screenPos.Y - offset.Y);
            }
        }

        private void OnButton_MouseUp(object sender, MouseEventArgs e) //helps with drag function
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isDrag)
                {
                    isDrag = false;
                    //buttonTarget = null;
                }
                mouseDown = false;
            }
        }

        public void ShowNoteEditForm(object sender, EventArgs e) //shows new form to edit note text
        {
            if (this.MdiParent != null) 
            {
                NoteEditForm childForm = new NoteEditForm(buttonTarget.Text, newText => buttonTarget.Text = newText);
                //childForm.MdiParent = this.MdiParent;
                childForm.StartPosition = FormStartPosition.Manual;
                childForm.WindowState = FormWindowState.Normal;
                childForm.Size = new Size(380, 450);
                Point center = this.PointToScreen(new Point(
                    (this.ClientSize.Width - childForm.Width) / 2,
                    (this.ClientSize.Height - childForm.Height) / 2
                ));
                childForm.Location = center;
                childForm.Show(this);
            }

        }

        public void DeleteNote(object sender, EventArgs e) //delete
        {
            Controls.Remove(buttonTarget);
            buttons.Remove(buttonTarget);
        }
        private void onChooseColorClick(object sender, MouseEventArgs e) //can choose colors
        {
            colorPanel.BringToFront();
            colorPanel.Visible = true;
        }

        private void onRenameButtonClick(object sender, MouseEventArgs e)
        {

        }
    }
}
