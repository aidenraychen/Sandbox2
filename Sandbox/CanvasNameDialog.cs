
namespace Sandbox
{
    public partial class CanvasNameDialog : Form
    {
        public string CanvasTitle;

        public CanvasNameDialog()
        {
            InitializeComponent();
        }

        public string GetCanvasTitle()
        {
            return renameTextBox.Text;
        }
        public void SetCanvasTitle(string value)
        {
            renameTextBox.Text = value;
        }

    }
}
