using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sandbox.frmCanvas;

namespace Sandbox
{

    public partial class MDISandbox : Form
    {
        //List<Button> buttons = new List<Button>();
        private int childFormNumber = 1;
        private SelectCanvas selectionScreen;
        bool CLEARINGALL = false; //decide whether to clear all application memory or not
        //public List<CanvasData> allCanvas;

        public MDISandbox()
        {
            InitializeComponent();
            HomePage home = new HomePage();
            home.MdiParent = this;
            home.WindowState = FormWindowState.Maximized;
            home.Show();
            MdiClient mdiClient = null;
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient mc)
                {
                    mdiClient = mc;
                    mdiClient.BackColor = Color.White;

                    break;
                }
            }

            this.BackColor = Color.White;

            if (CLEARINGALL)
            {
                ClearAllCanvasData(); //clears all data
            }
            selectionScreen = new SelectCanvas(); //creates select canvas upon load, since user may save a form before opening the select canvas window
            
            string path = Path.Combine( //dynamically get path to file
                AppDomain.CurrentDomain.BaseDirectory,
                "SandboxNotes.json"
            );

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                CanvasManager.AllCanvas = JsonSerializer.Deserialize<List<CanvasData>>(json) ?? new List<CanvasData>();
            }
            else
            {
                CanvasManager.AllCanvas = new List<CanvasData>();
            }
            if (CanvasManager.AllCanvas.Count > 0)
            {
                childFormNumber = (int)CanvasManager.AllCanvas.Count;
            }
            else
            {
                childFormNumber = 0;
            }
            foreach (var canvas in CanvasManager.AllCanvas) //makes buttons for selecting forms
                {
                    selectionScreen.createCanvasSelections(canvas.CanvasNum);
                }
        }
        public int getNextCanvasNumber() //form index assigning function
        {
            childFormNumber++;
            int current = childFormNumber;
            return current;
        }
        public void ShowNewForm(object sender, EventArgs e) //displays new form upon opening
        {
            CanvasData newCanvas = new CanvasData()
            {
                CanvasNum = childFormNumber,
                CanvasName = "Canvas " + (childFormNumber+1), //+1 necessary because this is before childFormNumber is updated, so it's 1 less than required
                Notes = new List<NoteData>()
            };
            CanvasManager.AllCanvas.Add(newCanvas);
            frmCanvas childForm = new frmCanvas(selectionScreen, childFormNumber, newCanvas);
            childForm.MdiParent = this;
            childForm.Text = "Window " + (childFormNumber+1);
            childForm.Show();
            childForm.BringToFront();
            childForm.TopMost = true;
            childForm.WindowState = FormWindowState.Maximized;
        }

        public void OpenFile(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
            selectionScreen.MdiParent = this;
            selectionScreen.Text = "Select Canvas";
            selectionScreen.WindowState = FormWindowState.Maximized;
            selectionScreen.AutoScroll = true;
            selectionScreen.TopMost = true;
            selectionScreen.Show();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        public void ClearAllCanvasData() //clears all data from application
        {
            string path = Path.Combine( //dynamically get path to file
                AppDomain.CurrentDomain.BaseDirectory,
                "SandboxNotes.json"
            );
            var emptyList = new List<CanvasData>();
            string json = JsonSerializer.Serialize(emptyList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);

            MessageBox.Show("All canvas data has been cleared.", "Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
