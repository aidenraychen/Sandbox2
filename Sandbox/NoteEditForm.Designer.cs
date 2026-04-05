namespace Sandbox
{
    partial class NoteEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            //textBox1.Location = new Point(ClientRectangle.Width/2, ClientRectangle.Height / 2);
            textBox1.Location = new Point(50,50);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(278, 244);
            textBox1.TabIndex = 0;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.ScrollToCaret();
            textBox1.ShortcutsEnabled = true;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(62,312);
            saveButton.Name = "Save";
            saveButton.Size = new Size(112, 34);
            saveButton.TabIndex = 1;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += onSave_Click;
            // 
            // button2
            // 
            cancelButton.Location = new Point(180, 312);
            cancelButton.Name = "Cancel";
            cancelButton.Size = new Size(112, 34);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.MouseClick += onCancel_Click;
            // 
            // NoteEditForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F); //frankly, idk what this is
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 400);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
            Controls.Add(textBox1);
            Name = "NoteEditForm";
            Text = "Text Input";
            ResumeLayout(false);
            PerformLayout();
        }

        //private void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        private TextBox textBox1;
        private Button saveButton;
        private Button cancelButton;
    }
}