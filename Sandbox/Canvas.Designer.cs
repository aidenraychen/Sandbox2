namespace Sandbox
{
    partial class Canvas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Canvas));
            createNoteButton = new Button();
            changeColorBtn = new Button();
            renameCanvasButton = new Button();
            saveCanvasButton = new Button();
            closeCanvasButton = new Button();
            deleteCanvasButton = new Button();
            noteEditMenu = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            colorMenu = new ContextMenuStrip(components);
            noteEditMenu.SuspendLayout();
            SuspendLayout();
            // 
            // createNoteButton
            // 
            createNoteButton.Image = (Image)resources.GetObject("createNoteButton.Image");
            createNoteButton.Location = new Point(0, 0);
            createNoteButton.Margin = new Padding(6, 5, 6, 5);
            createNoteButton.Name = "createNoteButton";
            createNoteButton.Size = new Size(190, 183);
            createNoteButton.TabIndex = 0;
            createNoteButton.Text = "+Note";
            createNoteButton.TextAlign = ContentAlignment.BottomCenter;
            createNoteButton.UseVisualStyleBackColor = true;
            createNoteButton.Click += onCreateNote_Click;
            // 
            // changeColorBtn
            // 
            changeColorBtn.Image = (Image)resources.GetObject("changeColorBtn.Image");
            changeColorBtn.Location = new Point(200, 0);
            changeColorBtn.Margin = new Padding(6, 5, 6, 5);
            changeColorBtn.Name = "changeColorBtn";
            changeColorBtn.Size = new Size(190, 183);
            changeColorBtn.TabIndex = 0;
            changeColorBtn.Text = "Color";
            changeColorBtn.TextAlign = ContentAlignment.BottomCenter;
            changeColorBtn.UseVisualStyleBackColor = true;
            changeColorBtn.MouseClick += onChooseColorClick;
            // 
            // renameCanvasButton
            // 
            renameCanvasButton.Image = (Image)resources.GetObject("renameCanvasButton.Image");
            renameCanvasButton.Location = new Point(600, 0);
            renameCanvasButton.Margin = new Padding(4);
            renameCanvasButton.Name = "renameCanvasButton";
            renameCanvasButton.Size = new Size(190, 183);
            renameCanvasButton.TabIndex = 1;
            renameCanvasButton.Text = "Rename";
            renameCanvasButton.TextAlign = ContentAlignment.BottomCenter;
            renameCanvasButton.UseVisualStyleBackColor = true;
            renameCanvasButton.MouseClick += onRenameCanvasClick;
            // 
            // saveCanvasButton
            // 
            saveCanvasButton.Image = (Image)resources.GetObject("saveCanvasButton.Image");
            saveCanvasButton.Location = new Point(400, 0);
            saveCanvasButton.Margin = new Padding(4);
            saveCanvasButton.Name = "saveCanvasButton";
            saveCanvasButton.Size = new Size(190, 183);
            saveCanvasButton.TabIndex = 1;
            saveCanvasButton.Text = "Save";
            saveCanvasButton.TextAlign = ContentAlignment.BottomCenter;
            saveCanvasButton.UseVisualStyleBackColor = true;
            saveCanvasButton.MouseClick += onSaveCanvas_Click;
            // 
            // closeCanvasButton
            // 
            closeCanvasButton.Location = new Point(800, 0);
            closeCanvasButton.Margin = new Padding(4);
            closeCanvasButton.Name = "closeCanvasButton";
            closeCanvasButton.Size = new Size(190, 183);
            closeCanvasButton.TabIndex = 1;
            closeCanvasButton.Text = "Close";
            closeCanvasButton.UseVisualStyleBackColor = true;
            closeCanvasButton.MouseClick += onCloseCanvasClick;
            // 
            // deleteCanvasButton
            // 
            deleteCanvasButton.Image = (Image)resources.GetObject("deleteCanvasButton.Image");
            deleteCanvasButton.Location = new Point(1200, 0);
            deleteCanvasButton.Margin = new Padding(4);
            deleteCanvasButton.Name = "deleteCanvasButton";
            deleteCanvasButton.Size = new Size(190, 183);
            deleteCanvasButton.TabIndex = 1;
            deleteCanvasButton.Text = "Delete";
            deleteCanvasButton.TextAlign = ContentAlignment.BottomCenter;
            deleteCanvasButton.UseVisualStyleBackColor = true;
            deleteCanvasButton.MouseClick += onDeleteCanvasClick;
            // 
            // noteEditMenu
            // 
            noteEditMenu.ImageScalingSize = new Size(24, 24);
            noteEditMenu.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, deleteToolStripMenuItem });
            noteEditMenu.Name = "contextMenuStrip1";
            noteEditMenu.Size = new Size(183, 100);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(182, 48);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += ShowNoteEditForm;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(182, 48);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += DeleteNote;
            // 
            // colorMenu
            // 
            colorMenu.ImageScalingSize = new Size(40, 40);
            colorMenu.Name = "colorMenu";
            colorMenu.Size = new Size(41, 4);
            // 
            // Canvas
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1549, 738);
            Controls.Add(saveCanvasButton);
            Controls.Add(createNoteButton);
            Controls.Add(changeColorBtn);
            Controls.Add(renameCanvasButton);
            Controls.Add(closeCanvasButton);
            Controls.Add(deleteCanvasButton);
            Margin = new Padding(6, 5, 6, 5);
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "Canvas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Canvas";
            noteEditMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button createNoteButton;
        private Button changeColorBtn;
        private Button saveCanvasButton;
        private Button renameCanvasButton;
        private Button closeCanvasButton;
        private Button deleteCanvasButton;

        private ContextMenuStrip noteEditMenu;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ContextMenuStrip colorMenu;

        private Panel canvasPanel;
    }
}
