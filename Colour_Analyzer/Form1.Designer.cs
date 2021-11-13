
namespace Colour_Analyzer
{
    partial class Form1
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
            this.outputInfo = new System.Windows.Forms.TextBox();
            this.goBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // outputInfo
            // 
            this.outputInfo.Location = new System.Drawing.Point(12, 12);
            this.outputInfo.Multiline = true;
            this.outputInfo.Name = "outputInfo";
            this.outputInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputInfo.Size = new System.Drawing.Size(660, 197);
            this.outputInfo.TabIndex = 0;
            // 
            // goBtn
            // 
            this.goBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.goBtn.ForeColor = System.Drawing.Color.MintCream;
            this.goBtn.Location = new System.Drawing.Point(575, 215);
            this.goBtn.Margin = new System.Windows.Forms.Padding(0);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(97, 34);
            this.goBtn.TabIndex = 1;
            this.goBtn.Text = "Go!";
            this.goBtn.UseVisualStyleBackColor = false;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 261);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.outputInfo);
            this.MaximumSize = new System.Drawing.Size(700, 300);
            this.Name = "Form1";
            this.Text = "Image Info Scanner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox outputInfo;
        private System.Windows.Forms.Button goBtn;
    }
}

