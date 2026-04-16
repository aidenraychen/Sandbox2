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
            noteEditMenu = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            colorMenu = new ContextMenuStrip(components);
            panWall = new Panel();
            panCommand = new Panel();
            saveCanvasButton = new Button();
            createNoteButton = new Button();
            changeColorBtn = new Button();
            renameCanvasButton = new Button();
            closeCanvasButton = new Button();
            deleteCanvasButton = new Button();
            noteEditMenu.SuspendLayout();
            panCommand.SuspendLayout();
            SuspendLayout();
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
            colorMenu.Size = new Size(61, 4);
            // 
            // panCommand
            // 
            panCommand.Controls.Add(saveCanvasButton);
            panCommand.Controls.Add(createNoteButton);
            panCommand.Controls.Add(changeColorBtn);
            panCommand.Controls.Add(renameCanvasButton);
            panCommand.Controls.Add(closeCanvasButton);
            panCommand.Controls.Add(deleteCanvasButton);
            panCommand.Dock = DockStyle.Top;
            panCommand.Location = new Point(0, 0);
            panCommand.Name = "panCommand";
            panCommand.Size = new Size(1632, 185);
            panCommand.TabIndex = 3;
            // 
            // panWall
            // 
            panWall.AutoScroll = false;
            panWall.BackColor = SystemColors.Control;
            panWall.Dock = DockStyle.Fill;
            panWall.Location = new Point(0, 212);
            panWall.Name = "panWall";
            
            panWall.TabIndex = 9;
            // 
            // saveCanvasButton
            // 
            saveCanvasButton.Image = (Image)resources.GetObject("saveCanvasButton.Image");
            saveCanvasButton.Location = new Point(400, 0);
            saveCanvasButton.Margin = new Padding(4);
            saveCanvasButton.Name = "saveCanvasButton";
            saveCanvasButton.Size = new Size(190, 183);
            saveCanvasButton.TabIndex = 3;
            saveCanvasButton.Text = "Save";
            saveCanvasButton.TextAlign = ContentAlignment.BottomCenter;
            saveCanvasButton.UseVisualStyleBackColor = true;
            saveCanvasButton.MouseClick += onSaveCanvas_Click;
            // 
            // createNoteButton
            // 
            createNoteButton.Image = (Image)resources.GetObject("createNoteButton.Image");
            createNoteButton.Location = new Point(0, 0);
            createNoteButton.Margin = new Padding(6, 5, 6, 5);
            createNoteButton.Name = "createNoteButton";
            createNoteButton.Size = new Size(190, 183);
            createNoteButton.TabIndex = 1;
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
            changeColorBtn.TabIndex = 2;
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
            renameCanvasButton.TabIndex = 4;
            renameCanvasButton.Text = "Rename";
            renameCanvasButton.TextAlign = ContentAlignment.BottomCenter;
            renameCanvasButton.UseVisualStyleBackColor = true;
            renameCanvasButton.MouseClick += onRenameCanvasClick;
            // 
            // closeCanvasButton
            // 
            closeCanvasButton.Location = new Point(800, 0);
            closeCanvasButton.Margin = new Padding(4);
            closeCanvasButton.Name = "closeCanvasButton";
            closeCanvasButton.Size = new Size(190, 183);
            closeCanvasButton.TabIndex = 5;
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
            deleteCanvasButton.TabIndex = 6;
            deleteCanvasButton.Text = "Delete";
            deleteCanvasButton.TextAlign = ContentAlignment.BottomCenter;
            deleteCanvasButton.UseVisualStyleBackColor = true;
            deleteCanvasButton.MouseClick += onDeleteCanvasClick;
            // 
            // Canvas
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1632, 1047);
            Controls.Add(panWall);
            Controls.Add(panCommand);
            Margin = new Padding(6, 5, 6, 5);
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "Canvas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Canvas";
            noteEditMenu.ResumeLayout(false);
            panCommand.ResumeLayout(false);
            ResumeLayout(false);
            
        }

        #endregion

        private ContextMenuStrip noteEditMenu;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ContextMenuStrip colorMenu;

        private Panel canvasPanel;
        private Panel panCommand;
        private Panel panWall;
        private Button saveCanvasButton;
        private Button createNoteButton;
        private Button changeColorBtn;
        private Button renameCanvasButton;
        private Button closeCanvasButton;
        private Button deleteCanvasButton;
    }
}
