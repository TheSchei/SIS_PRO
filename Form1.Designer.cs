
namespace SIS_PRO
{
    partial class MainWindow
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
            this.NumberOfChanelsLabel = new System.Windows.Forms.Label();
            this.NumberOfChanelsBox = new System.Windows.Forms.NumericUpDown();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.Start_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfChanelsBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NumberOfChanelsLabel
            // 
            this.NumberOfChanelsLabel.AutoSize = true;
            this.NumberOfChanelsLabel.Location = new System.Drawing.Point(13, 13);
            this.NumberOfChanelsLabel.Name = "NumberOfChanelsLabel";
            this.NumberOfChanelsLabel.Size = new System.Drawing.Size(78, 15);
            this.NumberOfChanelsLabel.TabIndex = 0;
            this.NumberOfChanelsLabel.Text = "Ilość kanałów";
            // 
            // NumberOfChanelsBox
            // 
            this.NumberOfChanelsBox.Location = new System.Drawing.Point(238, 13);
            this.NumberOfChanelsBox.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumberOfChanelsBox.Name = "NumberOfChanelsBox";
            this.NumberOfChanelsBox.Size = new System.Drawing.Size(120, 23);
            this.NumberOfChanelsBox.TabIndex = 2;
            this.NumberOfChanelsBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // LogTextBox
            // 
            this.LogTextBox.Location = new System.Drawing.Point(13, 142);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(345, 296);
            this.LogTextBox.TabIndex = 3;
            // 
            // Start_Button
            // 
            this.Start_Button.Location = new System.Drawing.Point(283, 113);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(75, 23);
            this.Start_Button.TabIndex = 4;
            this.Start_Button.Text = "Start";
            this.Start_Button.UseVisualStyleBackColor = true;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 450);
            this.Controls.Add(this.Start_Button);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.NumberOfChanelsBox);
            this.Controls.Add(this.NumberOfChanelsLabel);
            this.Name = "MainWindow";
            this.Text = "SIS Projekt 9";
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfChanelsBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NumberOfChanelsLabel;
        private System.Windows.Forms.NumericUpDown NumberOfChanelsBox;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Button Start_Button;
    }
}

