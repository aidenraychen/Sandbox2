namespace Sandbox
{
    partial class NoteEditDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteEditDialog));
            textBox1 = new TextBox();
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(55, 14);
            textBox1.Margin = new Padding(5);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(500, 480);
            textBox1.TabIndex = 0;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.Navy;
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(55, 538);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(200, 60);
            saveButton.TabIndex = 4;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += onSave_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Navy;
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(355, 538);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(200, 60);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += onCancel_Click;
            // 
            // NoteEditDialog
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(655, 667);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
            Controls.Add(textBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            Name = "NoteEditDialog";
            Text = "Text Input";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button saveButton;
        private Button cancelButton;
    }
}