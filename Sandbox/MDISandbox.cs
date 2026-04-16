using System.Text.Json;

namespace Sandbox
{
    public partial class MDISandbox : Form
    {
        private SelectCanvas _selectionScreen;
        bool CLEARINGALL = false; // for Debug Purpose. decide whether to clear all application memory or not

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
            CanvasManager.EnsureLoaded();
            _selectionScreen = new SelectCanvas(); //creates select canvas upon load, since user may save a form before opening the select canvas window

        }


        public void ShowNewForm(object sender, EventArgs e) //displays new form upon opening
        {

            Canvas canvasToBeOpened = new Canvas();
            canvasToBeOpened.InitCanvas(_selectionScreen, string.Empty,true);

            canvasToBeOpened.MdiParent = this;
            canvasToBeOpened.Show();
            canvasToBeOpened.BringToFront();
            canvasToBeOpened.TopMost = true;
            canvasToBeOpened.WindowState = FormWindowState.Maximized;
        }

        public void OpenFile(object sender, EventArgs e) //display select canvas screen
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
            _selectionScreen.PopulateCanvasSelections();

            _selectionScreen.MdiParent = this;
            _selectionScreen.WindowState = FormWindowState.Maximized;
            _selectionScreen.Text = "Select Canvas";
            _selectionScreen.TopMost = true;
            _selectionScreen.Show();

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
            LayoutMdi(MdiLayout.Cascade); //arranges child windows in a
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
