namespace BouncyBalls
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
            this.components = new System.ComponentModel.Container();
            this.UI_Btn_AddHyperBall = new System.Windows.Forms.Button();
            this.UI_Btn_AddRandomBall = new System.Windows.Forms.Button();
            this.Tick = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UI_Btn_AddHyperBall
            // 
            this.UI_Btn_AddHyperBall.Location = new System.Drawing.Point(12, 64);
            this.UI_Btn_AddHyperBall.Name = "UI_Btn_AddHyperBall";
            this.UI_Btn_AddHyperBall.Size = new System.Drawing.Size(360, 35);
            this.UI_Btn_AddHyperBall.TabIndex = 0;
            this.UI_Btn_AddHyperBall.Text = "Add HyperBall";
            this.UI_Btn_AddHyperBall.UseVisualStyleBackColor = true;
            this.UI_Btn_AddHyperBall.Click += new System.EventHandler(this.UI_Btn_AddHyperBall_Click);
            // 
            // UI_Btn_AddRandomBall
            // 
            this.UI_Btn_AddRandomBall.Location = new System.Drawing.Point(12, 12);
            this.UI_Btn_AddRandomBall.Name = "UI_Btn_AddRandomBall";
            this.UI_Btn_AddRandomBall.Size = new System.Drawing.Size(360, 35);
            this.UI_Btn_AddRandomBall.TabIndex = 1;
            this.UI_Btn_AddRandomBall.Text = "Add Random Ball";
            this.UI_Btn_AddRandomBall.UseVisualStyleBackColor = true;
            this.UI_Btn_AddRandomBall.Click += new System.EventHandler(this.UI_RandomBtn_Click);
            // 
            // Tick
            // 
            this.Tick.Enabled = true;
            this.Tick.Interval = 20;
            this.Tick.Tick += new System.EventHandler(this.Tick_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 111);
            this.Controls.Add(this.UI_Btn_AddRandomBall);
            this.Controls.Add(this.UI_Btn_AddHyperBall);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UI_Btn_AddHyperBall;
        private System.Windows.Forms.Button UI_Btn_AddRandomBall;
        private System.Windows.Forms.Timer Tick;
    }
}

