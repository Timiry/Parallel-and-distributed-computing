namespace laba4
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
            btnLoadImage = new Button();
            openFileDialog1 = new OpenFileDialog();
            btnIncreaseBrightness = new Button();
            pictureBoxOriginal = new PictureBox();
            pictureBoxResult = new PictureBox();
            btnIncreaseBrightnessSingle = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            labelWorkTime = new Label();
            labelImgSize = new Label();
            labelProcCount = new Label();
            trackBar1 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxResult).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(29, 16);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(194, 29);
            btnLoadImage.TabIndex = 0;
            btnLoadImage.Text = "Загрузить изображение";
            btnLoadImage.UseVisualStyleBackColor = true;
            btnLoadImage.Click += btnLoadImage_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnIncreaseBrightness
            // 
            btnIncreaseBrightness.Location = new Point(249, 16);
            btnIncreaseBrightness.Name = "btnIncreaseBrightness";
            btnIncreaseBrightness.Size = new Size(256, 29);
            btnIncreaseBrightness.TabIndex = 1;
            btnIncreaseBrightness.Text = "Изменить яркость много потоков";
            btnIncreaseBrightness.UseVisualStyleBackColor = true;
            btnIncreaseBrightness.Click += btnIncreaseBrightness_Click;
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.Location = new Point(29, 71);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.Size = new Size(550, 550);
            pictureBoxOriginal.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxOriginal.TabIndex = 2;
            pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxResult
            // 
            pictureBoxResult.Location = new Point(620, 71);
            pictureBoxResult.Name = "pictureBoxResult";
            pictureBoxResult.Size = new Size(550, 550);
            pictureBoxResult.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxResult.TabIndex = 3;
            pictureBoxResult.TabStop = false;
            // 
            // btnIncreaseBrightnessSingle
            // 
            btnIncreaseBrightnessSingle.Location = new Point(525, 16);
            btnIncreaseBrightnessSingle.Name = "btnIncreaseBrightnessSingle";
            btnIncreaseBrightnessSingle.Size = new Size(226, 29);
            btnIncreaseBrightnessSingle.TabIndex = 4;
            btnIncreaseBrightnessSingle.Text = "Изменить яркость 1 поток";
            btnIncreaseBrightnessSingle.UseVisualStyleBackColor = true;
            btnIncreaseBrightnessSingle.Click += btnIncreaseBrightnessSingle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 640);
            label1.Name = "label1";
            label1.Size = new Size(172, 20);
            label1.TabIndex = 5;
            label1.Text = "Количество процессов:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 675);
            label2.Name = "label2";
            label2.Size = new Size(163, 20);
            label2.TabIndex = 6;
            label2.Text = "Размер изображения:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 709);
            label3.Name = "label3";
            label3.Size = new Size(168, 20);
            label3.TabIndex = 7;
            label3.Text = "Время обработки (мс):";
            // 
            // labelWorkTime
            // 
            labelWorkTime.AutoSize = true;
            labelWorkTime.Location = new Point(224, 709);
            labelWorkTime.Name = "labelWorkTime";
            labelWorkTime.Size = new Size(0, 20);
            labelWorkTime.TabIndex = 10;
            // 
            // labelImgSize
            // 
            labelImgSize.AutoSize = true;
            labelImgSize.Location = new Point(224, 675);
            labelImgSize.Name = "labelImgSize";
            labelImgSize.Size = new Size(0, 20);
            labelImgSize.TabIndex = 9;
            // 
            // labelProcCount
            // 
            labelProcCount.AutoSize = true;
            labelProcCount.Location = new Point(224, 640);
            labelProcCount.Name = "labelProcCount";
            labelProcCount.Size = new Size(0, 20);
            labelProcCount.TabIndex = 8;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(788, 9);
            trackBar1.Maximum = 100;
            trackBar1.Minimum = -100;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(330, 56);
            trackBar1.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1201, 752);
            Controls.Add(trackBar1);
            Controls.Add(labelWorkTime);
            Controls.Add(labelImgSize);
            Controls.Add(labelProcCount);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnIncreaseBrightnessSingle);
            Controls.Add(pictureBoxResult);
            Controls.Add(pictureBoxOriginal);
            Controls.Add(btnIncreaseBrightness);
            Controls.Add(btnLoadImage);
            Name = "Form1";
            Text = "Яркость изображений";
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxResult).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadImage;
        private OpenFileDialog openFileDialog1;
        private Button btnIncreaseBrightness;
        private PictureBox pictureBoxOriginal;
        private PictureBox pictureBoxResult;
        private Button btnIncreaseBrightnessSingle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label labelWorkTime;
        private Label labelImgSize;
        private Label labelProcCount;
        private TrackBar trackBar1;
    }
}
