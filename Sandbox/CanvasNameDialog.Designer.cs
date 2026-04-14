namespace Sandbox
{
    partial class CanvasNameDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CanvasNameDialog));
            renameLabel = new Label();
            renameTextBox = new TextBox();
            renameCanvasSaveButton = new Button();
            renameCanvasCancelButton = new Button();
            SuspendLayout();
            // 
            // renameLabel
            // 
            renameLabel.ForeColor = Color.Black;
            renameLabel.Location = new Point(20, 50);
            renameLabel.Name = "renameLabel";
            renameLabel.Size = new Size(110, 50);
            renameLabel.TabIndex = 0;
            renameLabel.Text = "Name : ";
            // 
            // renameTextBox
            // 
            renameTextBox.BorderStyle = BorderStyle.FixedSingle;
            renameTextBox.Location = new Point(180, 50);
            renameTextBox.Name = "renameTextBox";
            renameTextBox.Size = new Size(350, 47);
            renameTextBox.TabIndex = 1;
            // 
            // renameCanvasSaveButton
            // 
            renameCanvasSaveButton.BackColor = Color.Navy;
            renameCanvasSaveButton.ForeColor = Color.White;
            renameCanvasSaveButton.Location = new Point(50, 150);
            renameCanvasSaveButton.Name = "renameCanvasSaveButton";
            renameCanvasSaveButton.Size = new Size(200, 60);
            renameCanvasSaveButton.TabIndex = 2;
            renameCanvasSaveButton.Text = "Save";
            renameCanvasSaveButton.UseVisualStyleBackColor = false;
            renameCanvasSaveButton.MouseClick += onRenameCanvasSaveButtonClick;
            // 
            // renameCanvasCancelButton
            // 
            renameCanvasCancelButton.BackColor = Color.Navy;
            renameCanvasCancelButton.ForeColor = Color.White;
            renameCanvasCancelButton.Location = new Point(350, 150);
            renameCanvasCancelButton.Name = "renameCanvasCancelButton";
            renameCanvasCancelButton.Size = new Size(200, 60);
            renameCanvasCancelButton.TabIndex = 3;
            renameCanvasCancelButton.Text = "Cancel";
            renameCanvasCancelButton.UseVisualStyleBackColor = false;
            renameCanvasCancelButton.MouseClick += onRenameCanvasCancelButtonClick;
            // 
            // CanvasNameDialog
            // 
            ClientSize = new Size(627, 260);
            Controls.Add(renameLabel);
            Controls.Add(renameTextBox);
            Controls.Add(renameCanvasSaveButton);
            Controls.Add(renameCanvasCancelButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CanvasNameDialog";
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion

        private TextBox renameTextBox;
        private Label renameLabel;
        private Button renameCanvasSaveButton;
        private Button renameCanvasCancelButton;

    }
}