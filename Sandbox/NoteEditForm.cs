using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Windows.Storage;

namespace Sandbox
{
    public partial class NoteEditForm : Form
    {
        private readonly Action<string> _saveCallback;
        public NoteEditForm(string initialText, Action<string> saveCallback) //make textbook
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

        private void onCancel_Click(object sender, MouseEventArgs e) //close text editor
        {
            this.Close();
        }

        //stuff for storage
        //private StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        //private StorageFile? noteFile = null;
        //private string fileName = "note.txt";
    }
}
