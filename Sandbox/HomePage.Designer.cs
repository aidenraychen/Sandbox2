namespace Sandbox
{
    partial class HomePage
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
            Button newCanvas;
            Button openCanvas;
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.Text = "HomePage";
            for (int i = 1; i < 4; i++)
            {
                Panel horizontalLine = new Panel
                {
                    BackColor = Color.Black,
                    Height = 1,
                    Width = 12000,
                    Location = new Point(0, i * 150 + 75),

                };
                Controls.Add(horizontalLine);
            }
            Label welcomeLabel = new Label
            {
                Text = "Welcome to Sandbox",
                Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(30, 80)
            };
            Controls.Add(welcomeLabel);

            newCanvas = new Button
            {
                Size = new Size(12000, 150),

                Name = "Create a new canvas",
                Text = "Create a new canvas",
                Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                //BackColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(0, 225),
                Padding = new Padding(30, 0, 0, 0),
            };

            openCanvas = new Button
            {
                Size = new Size(12000, 150),

                Name = "Open an existing canvas",
                Text = "Open an existing canvas",
                Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                //BackColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(0, 375),
                Padding = new Padding(30, 0, 0, 0),
            };
            openCanvas.MouseClick += OpenFile;
            newCanvas.MouseClick += ShowNewForm;
            Controls.Add(newCanvas);
            Controls.Add(openCanvas);
        }

        #endregion
    }
}