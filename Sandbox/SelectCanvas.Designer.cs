namespace Sandbox
{
    partial class SelectCanvas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectCanvas));
            backButton = new Button();
            NoCanvasLabel = new Label();
            panContainer = new Panel();
            label1 = new Label();
            panContainer.SuspendLayout();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.Image = (Image)resources.GetObject("backButton.Image");
            backButton.Location = new Point(0, 0);
            backButton.Margin = new Padding(4);
            backButton.Name = "backButton";
            backButton.Size = new Size(186, 179);
            backButton.TabIndex = 0;
            backButton.Text = "Back";
            backButton.TextAlign = ContentAlignment.BottomCenter;
            backButton.UseVisualStyleBackColor = true;
            backButton.MouseClick += onBackButtonClick;
            // 
            // NoCanvasLabel
            // 
            NoCanvasLabel.ForeColor = Color.Black;
            NoCanvasLabel.Location = new Point(392, 86);
            NoCanvasLabel.Name = "NoCanvasLabel";
            NoCanvasLabel.Size = new Size(440, 50);
            NoCanvasLabel.TabIndex = 1;
            NoCanvasLabel.Text = "There is no existed canvas.";
            NoCanvasLabel.Visible = false;
            // 
            // panContainer
            // 
            panContainer.AutoScroll = true;
            panContainer.BackColor = SystemColors.Control;
            panContainer.Controls.Add(label1);
            panContainer.Dock = DockStyle.Right;
            panContainer.Location = new Point(194, 0);
            panContainer.Margin = new Padding(4);
            panContainer.Name = "panContainer";
            panContainer.Size = new Size(915, 912);
            panContainer.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(4, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(451, 54);
            label1.TabIndex = 0;
            label1.Text = "Open an existing canvas";
            // 
            // SelectCanvas
            // 
            BackColor = SystemColors.Control;
            ClientSize = new Size(1109, 912);
            ControlBox = false;
            Controls.Add(panContainer);
            Controls.Add(NoCanvasLabel);
            Controls.Add(backButton);
            Margin = new Padding(4);
            Name = "SelectCanvas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select Canvas";
            panContainer.ResumeLayout(false);
            panContainer.PerformLayout();
            ResumeLayout(false);
        }

        private void Button1_MouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button backButton;
        private Label NoCanvasLabel;
        private Panel panContainer;
        private Label label1;
    }
}