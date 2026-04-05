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
        public MDISandbox()
        {
            InitializeComponent();
            if (CLEARINGALL)
            {
                ClearAllCanvasData(); //clears all data
            }
            selectionScreen = new SelectCanvas(); //creates select canvas upon load, since user may save a form before opening the select canvas window
            List<CanvasData> allCanvas;
            string path = Path.Combine( //dynamically get path to file
                AppDomain.CurrentDomain.BaseDirectory,
                "SandboxNotes.json"
            );

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                allCanvas = JsonSerializer.Deserialize<List<CanvasData>>(json) ?? new List<CanvasData>();
            }
            else
            {
                allCanvas = new List<CanvasData>();
            }
            if (allCanvas.Count > 0)
            {
                childFormNumber = (int)allCanvas.Count + 1;
            }
            else
            {
                childFormNumber = 1;
            }
            foreach (var canvas in allCanvas) //makes buttons for selecting forms
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
        private void ShowNewForm(object sender, EventArgs e) //displays new form upon opening
        {
            frmCanvas childForm = new frmCanvas(selectionScreen, childFormNumber);
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber;
            childForm.Show();
            childForm.BringToFront();
            childForm.WindowState = FormWindowState.Maximized;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
            selectionScreen.MdiParent = this;
            selectionScreen.Text = "Window ";
            selectionScreen.WindowState = FormWindowState.Maximized;
            selectionScreen.AutoScroll = true;
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

        //private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //}

        //private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //}

        //private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //}

        //private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        //}

        //private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        //}

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
