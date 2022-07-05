namespace FakeButton
{
    partial class Form1
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
            this.queLabel = new System.Windows.Forms.Label();
            this.RightButton = new System.Windows.Forms.Button();
            this.WrongButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // queLabel
            // 
            this.queLabel.AutoSize = true;
            this.queLabel.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.queLabel.Location = new System.Drawing.Point(170, 182);
            this.queLabel.Name = "queLabel";
            this.queLabel.Size = new System.Drawing.Size(645, 128);
            this.queLabel.TabIndex = 0;
            this.queLabel.Text = "who is better";
            // 
            // RightButton
            // 
            this.RightButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.RightButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RightButton.ForeColor = System.Drawing.Color.Black;
            this.RightButton.Location = new System.Drawing.Point(649, 561);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(120, 120);
            this.RightButton.TabIndex = 1;
            this.RightButton.Text = "Trump";
            this.RightButton.UseVisualStyleBackColor = false;
            // 
            // WrongButton
            // 
            this.WrongButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.WrongButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WrongButton.ForeColor = System.Drawing.Color.Black;
            this.WrongButton.Location = new System.Drawing.Point(170, 561);
            this.WrongButton.Margin = new System.Windows.Forms.Padding(0);
            this.WrongButton.Name = "WrongButton";
            this.WrongButton.Size = new System.Drawing.Size(120, 120);
            this.WrongButton.TabIndex = 1;
            this.WrongButton.Text = "Baiden";
            this.WrongButton.UseVisualStyleBackColor = false;
            this.WrongButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnWrongButtonMouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.Controls.Add(this.WrongButton);
            this.Controls.Add(this.RightButton);
            this.Controls.Add(this.queLabel);
            this.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.MinimumSize = new System.Drawing.Size(1000, 1000);
            this.Name = "Form1";
            this.Text = "questionary";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnForm1Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label queLabel;
        private Button RightButton;
        private Button WrongButton;
    }
}