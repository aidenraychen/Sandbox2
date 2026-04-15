
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

    }
}
