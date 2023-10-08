namespace BrightnessYUV
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button3 = new System.Windows.Forms.Button();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(40, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(495, 283);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.ForeColor = System.Drawing.Color.Ivory;
            this.button1.Location = new System.Drawing.Point(96, 339);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Открыть файл";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(582, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button2.ForeColor = System.Drawing.Color.Ivory;
            this.button2.Location = new System.Drawing.Point(355, 339);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 26);
            this.button2.TabIndex = 4;
            this.button2.Text = "Применить";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(568, 24);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(100, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button3.ForeColor = System.Drawing.Color.Ivory;
            this.button3.Location = new System.Drawing.Point(233, 339);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 26);
            this.button3.TabIndex = 6;
            this.button3.Text = "Сброс";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(568, 94);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(100, 45);
            this.trackBar2.TabIndex = 8;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(570, 166);
            this.trackBar3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(100, 45);
            this.trackBar3.TabIndex = 9;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(575, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Общая яркость";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(593, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "канал Y";
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(568, 246);
            this.trackBar4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(100, 45);
            this.trackBar4.TabIndex = 12;
            this.trackBar4.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(593, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "канал U";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(592, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "канал V";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Highlight;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(96, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 21);
            this.label6.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 376);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Label label1;
        private Button button2;
        private TrackBar trackBar1;
        private Button button3;
        private TrackBar trackBar2;
        private TrackBar trackBar3;
        private Label label2;
        private Label label3;
        private TrackBar trackBar4;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}