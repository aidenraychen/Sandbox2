
namespace Sandbox
{
    public partial class CanvasNameDialog : Form
    {
        public string CanvasTitle;

        public CanvasNameDialog()
        {
            InitializeComponent();
        }

        public string GetCanvasTitle() //gets text inside the text box
        {
            return renameTextBox.Text;
        }
        public void SetCanvasTitle(string value) //sets canvas title to parameter value, which is used w
        {
            renameTextBox.Text = value;
        }

    }
}
