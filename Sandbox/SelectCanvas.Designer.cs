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
            // SelectCanvas
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 615);
            ControlBox = false;
            Controls.Add(NoCanvasLabel);
            Controls.Add(backButton);
            Margin = new Padding(4);
            Name = "SelectCanvas";
            Text = "Select Canvas";
            ResumeLayout(false);
        }

        private void Button1_MouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button backButton;
        private Label NoCanvasLabel;
    }
}