
namespace Sandbox
{
    public partial class NoteEditDialog : Form
    {
        private readonly Action<string> _saveCallback;
        public NoteEditDialog(string initialText, Action<string> saveCallback) //make textbook
        {
            InitializeComponent();
            textBox1.Text = initialText; //sets initial text for text editor
            _saveCallback = saveCallback; //links text in editor to note
        }

        private void onSave_Click(object sender, EventArgs e) //saves text to note
        {
            var textboxContent = textBox1.Text;
            string path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "SandboxNoteText.txt"
            );
            //string noteText = @"C:\Users\Aiden\source\repos\Sandbox\SandboxNoteText.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(textboxContent);
            }
            _saveCallback?.Invoke(textBox1.Text);
            string readText = File.ReadAllText(path);
            System.Diagnostics.Debug.WriteLine(readText);
            this.Close();
        }

        private void onCancel_Click(object sender, EventArgs e) //close text editor
        {
            this.Close();
        }

    }
}
