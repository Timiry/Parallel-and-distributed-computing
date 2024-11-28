namespace laba5
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
            textBoxCount = new TextBox();
            label1 = new Label();
            buttonStart = new Button();
            SuspendLayout();
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(198, 18);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(125, 27);
            textBoxCount.TabIndex = 0;
            textBoxCount.Text = "5";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 21);
            label1.Name = "label1";
            label1.Size = new Size(173, 20);
            label1.TabIndex = 1;
            label1.Text = "Количество философов";
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(344, 17);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(94, 29);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "Старт";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 506);
            Controls.Add(buttonStart);
            Controls.Add(label1);
            Controls.Add(textBoxCount);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Философы";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxCount;
        private Label label1;
        private Button buttonStart;
    }
}
