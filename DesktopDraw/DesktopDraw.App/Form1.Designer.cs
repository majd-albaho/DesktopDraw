namespace DesktopDraw.App
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
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            drawBeginTxtBox = new TextBox();
            drawEndTxtBox = new TextBox();
            previewPictureBox = new PictureBox();
            drawPictureBox = new PictureBox();
            trackBar1 = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            trackBar2 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)drawPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(29, 36);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Insert picture";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(175, 36);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "Draw picture";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(294, 24);
            button3.Name = "button3";
            button3.Size = new Size(126, 46);
            button3.TabIndex = 2;
            button3.Text = "Start draw area";
            button3.UseVisualStyleBackColor = true;
            button3.MouseDown += button3_MouseDown;
            button3.MouseUp += button3_MouseUp;
            // 
            // button4
            // 
            button4.Location = new Point(426, 19);
            button4.Name = "button4";
            button4.Size = new Size(125, 51);
            button4.TabIndex = 3;
            button4.Text = "End draw area";
            button4.UseVisualStyleBackColor = true;
            button4.MouseDown += button4_MouseDown;
            button4.MouseUp += button4_MouseUp;
            // 
            // drawBeginTxtBox
            // 
            drawBeginTxtBox.Location = new Point(568, 27);
            drawBeginTxtBox.Name = "drawBeginTxtBox";
            drawBeginTxtBox.Size = new Size(100, 23);
            drawBeginTxtBox.TabIndex = 4;
            // 
            // drawEndTxtBox
            // 
            drawEndTxtBox.Location = new Point(568, 84);
            drawEndTxtBox.Name = "drawEndTxtBox";
            drawEndTxtBox.Size = new Size(100, 23);
            drawEndTxtBox.TabIndex = 5;
            // 
            // previewPictureBox
            // 
            previewPictureBox.BorderStyle = BorderStyle.FixedSingle;
            previewPictureBox.Location = new Point(12, 116);
            previewPictureBox.Name = "previewPictureBox";
            previewPictureBox.Size = new Size(247, 257);
            previewPictureBox.TabIndex = 6;
            previewPictureBox.TabStop = false;
            // 
            // drawPictureBox
            // 
            drawPictureBox.BorderStyle = BorderStyle.FixedSingle;
            drawPictureBox.Location = new Point(265, 116);
            drawPictureBox.Name = "drawPictureBox";
            drawPictureBox.Size = new Size(247, 257);
            drawPictureBox.TabIndex = 7;
            drawPictureBox.TabStop = false;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(568, 168);
            trackBar1.Maximum = 70;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(197, 45);
            trackBar1.TabIndex = 8;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(594, 139);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 9;
            label1.Text = "x axis timeout";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(594, 224);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 11;
            label2.Text = "y axis timeout";
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(568, 253);
            trackBar2.Maximum = 70;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(197, 45);
            trackBar2.TabIndex = 10;
            trackBar2.Value = 40;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(trackBar2);
            Controls.Add(label1);
            Controls.Add(trackBar1);
            Controls.Add(drawPictureBox);
            Controls.Add(previewPictureBox);
            Controls.Add(drawEndTxtBox);
            Controls.Add(drawBeginTxtBox);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)drawPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox drawBeginTxtBox;
        private TextBox drawEndTxtBox;
        private PictureBox previewPictureBox;
        private PictureBox drawPictureBox;
        private TrackBar trackBar1;
        private Label label1;
        private Label label2;
        private TrackBar trackBar2;
    }
}
