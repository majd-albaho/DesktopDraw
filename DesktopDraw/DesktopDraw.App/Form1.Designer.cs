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
            previewPictureBox = new PictureBox();
            drawPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)drawPictureBox).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(157, 67);
            button1.TabIndex = 0;
            button1.Text = "Insert picture";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(175, 12);
            button2.Name = "button2";
            button2.Size = new Size(191, 67);
            button2.TabIndex = 1;
            button2.Text = "Draw picture";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(426, 12);
            button3.Name = "button3";
            button3.Size = new Size(194, 67);
            button3.TabIndex = 2;
            button3.Text = "Start draw area";
            button3.UseVisualStyleBackColor = true;
            button3.MouseDown += button3_MouseDown;
            button3.MouseUp += button3_MouseUp;
            // 
            // button4
            // 
            button4.Location = new Point(626, 12);
            button4.Name = "button4";
            button4.Size = new Size(162, 67);
            button4.TabIndex = 3;
            button4.Text = "End draw area";
            button4.UseVisualStyleBackColor = true;
            button4.MouseDown += button4_MouseDown;
            button4.MouseUp += button4_MouseUp;
            // 
            // previewPictureBox
            // 
            previewPictureBox.BorderStyle = BorderStyle.FixedSingle;
            previewPictureBox.Location = new Point(12, 85);
            previewPictureBox.Name = "previewPictureBox";
            previewPictureBox.Size = new Size(354, 353);
            previewPictureBox.TabIndex = 6;
            previewPictureBox.TabStop = false;
            // 
            // drawPictureBox
            // 
            drawPictureBox.BorderStyle = BorderStyle.FixedSingle;
            drawPictureBox.Location = new Point(426, 85);
            drawPictureBox.Name = "drawPictureBox";
            drawPictureBox.Size = new Size(362, 353);
            drawPictureBox.TabIndex = 7;
            drawPictureBox.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(drawPictureBox);
            Controls.Add(previewPictureBox);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)drawPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private PictureBox previewPictureBox;
        private PictureBox drawPictureBox;
    }
}
