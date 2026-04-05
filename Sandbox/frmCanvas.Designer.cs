namespace Sandbox
{
    partial class frmCanvas
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            createNoteButton = new Button();
            noteEditMenu = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            changeColorBtn = new Button();
            saveCanvasButton = new Button();
            testButton = new Button();
            colorMenu = new ContextMenuStrip();
            renameCanvasButton = new Button();
            noteEditMenu.SuspendLayout();
            SuspendLayout();
            // 
            // createNoteButton
            // 
            createNoteButton.Location = new Point(0, 0);
            createNoteButton.Margin = new Padding(4, 4, 4, 4);
            createNoteButton.Name = "createNoteButton";
            createNoteButton.Size = new Size(134, 134);
            createNoteButton.TabIndex = 0;
            createNoteButton.Text = "+Note";
            createNoteButton.UseVisualStyleBackColor = true;
            createNoteButton.Click += onCreateNote_Click;
            // 
            // noteEditMenu
            // 
            noteEditMenu.ImageScalingSize = new Size(24, 24);
            noteEditMenu.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, deleteToolStripMenuItem });
            noteEditMenu.Name = "contextMenuStrip1";
            noteEditMenu.Size = new Size(147, 76);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(146, 36);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += ShowNoteEditForm;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(146, 36);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += DeleteNote;
            // 
            // changeColorBtn
            // 
            changeColorBtn.Location = new Point(134, 0);
            changeColorBtn.Margin = new Padding(4, 4, 4, 4);
            changeColorBtn.Name = "changeColorBtn";
            changeColorBtn.Size = new Size(134, 134);
            changeColorBtn.TabIndex = 0;
            changeColorBtn.Text = "Color";
            changeColorBtn.UseVisualStyleBackColor = true;
            changeColorBtn.MouseClick += onChooseColorClick;
            // 
            // button2
            // 
            saveCanvasButton.Location = new Point(268, 0);
            saveCanvasButton.Name = "SaveCanvas";
            saveCanvasButton.Size = new Size(134, 134);
            saveCanvasButton.TabIndex = 1;
            saveCanvasButton.Text = "Save";
            saveCanvasButton.UseVisualStyleBackColor = true;
            saveCanvasButton.MouseClick += onSaveButton_Click;

            renameCanvasButton.Location = new Point(134*3, 0);
            renameCanvasButton.Name = "SaveCanvas";
            renameCanvasButton.Size = new Size(134, 134);
            renameCanvasButton.TabIndex = 1;
            renameCanvasButton.Text = "Save";
            renameCanvasButton.UseVisualStyleBackColor = true;
            renameCanvasButton.MouseClick += onRenameButtonClick;

            testButton.Location = new Point(500, 0);
            testButton.Name = _formNum.ToString();
            testButton.Size = new Size(134, 134);
            testButton.TabIndex = 1;
            testButton.Text = _formNum.ToString();
            testButton.UseVisualStyleBackColor = true;
            testButton.Hide();
            // 
            // frmCanvas
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 540);
            Controls.Add(saveCanvasButton);
            Controls.Add(createNoteButton);
            Controls.Add(changeColorBtn);
            Controls.Add(testButton);
            //Controls.Add(createDocButton);
            Margin = new Padding(4, 4, 4, 4);
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "frmCanvas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sandbox";
            Load += Form1_Load;
            noteEditMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button createNoteButton;
        //private Button createDocButton;
        private Button testButton;
        private Button changeColorBtn;
        private Button writeButton;
        private ContextMenuStrip noteEditMenu;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Button saveCanvasButton;
        private ContextMenuStrip colorMenu;
        private Button renameCanvasButton;
    }
}
