
namespace Sandbox
{
    public partial class CanvasNameDialog : Form
    {
        public string CanvasTitle;

        public CanvasNameDialog()
        {
            InitializeComponent();
        }

        public string getCanvasTitle()
        {
            return renameTextBox.Text;
        }
        public void setCanvasTitle(string value)
        {
            renameTextBox.Text = value;
        }

        private void onRenameCanvasSaveButtonClick(object sender, MouseEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void onRenameCanvasCancelButtonClick(object sender, MouseEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
