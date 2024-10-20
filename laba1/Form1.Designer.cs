namespace laba1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Suspend1 = new System.Windows.Forms.Button();
            this.Resume1 = new System.Windows.Forms.Button();
            this.Abort1 = new System.Windows.Forms.Button();
            this.Abort2 = new System.Windows.Forms.Button();
            this.Resume2 = new System.Windows.Forms.Button();
            this.Suspend2 = new System.Windows.Forms.Button();
            this.state1 = new System.Windows.Forms.Label();
            this.state2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Значение переменной";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Поток 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Поток 2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(382, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Обновить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Suspend1
            // 
            this.Suspend1.Location = new System.Drawing.Point(32, 125);
            this.Suspend1.Name = "Suspend1";
            this.Suspend1.Size = new System.Drawing.Size(81, 23);
            this.Suspend1.TabIndex = 5;
            this.Suspend1.Text = "Suspend";
            this.Suspend1.UseVisualStyleBackColor = true;
            this.Suspend1.Click += new System.EventHandler(this.Suspend1_Click);
            // 
            // Resume1
            // 
            this.Resume1.Location = new System.Drawing.Point(192, 125);
            this.Resume1.Name = "Resume1";
            this.Resume1.Size = new System.Drawing.Size(75, 23);
            this.Resume1.TabIndex = 6;
            this.Resume1.Text = "Resume";
            this.Resume1.UseVisualStyleBackColor = true;
            this.Resume1.Click += new System.EventHandler(this.Resume1_Click);
            // 
            // Abort1
            // 
            this.Abort1.Location = new System.Drawing.Point(368, 125);
            this.Abort1.Name = "Abort1";
            this.Abort1.Size = new System.Drawing.Size(75, 23);
            this.Abort1.TabIndex = 7;
            this.Abort1.Text = "Abort";
            this.Abort1.UseVisualStyleBackColor = true;
            this.Abort1.Click += new System.EventHandler(this.Abort1_Click);
            // 
            // Abort2
            // 
            this.Abort2.Location = new System.Drawing.Point(366, 270);
            this.Abort2.Name = "Abort2";
            this.Abort2.Size = new System.Drawing.Size(75, 23);
            this.Abort2.TabIndex = 10;
            this.Abort2.Text = "Abort";
            this.Abort2.UseVisualStyleBackColor = true;
            this.Abort2.Click += new System.EventHandler(this.Abort2_Click);
            // 
            // Resume2
            // 
            this.Resume2.Location = new System.Drawing.Point(190, 270);
            this.Resume2.Name = "Resume2";
            this.Resume2.Size = new System.Drawing.Size(75, 23);
            this.Resume2.TabIndex = 9;
            this.Resume2.Text = "Resume";
            this.Resume2.UseVisualStyleBackColor = true;
            this.Resume2.Click += new System.EventHandler(this.Resume2_Click);
            // 
            // Suspend2
            // 
            this.Suspend2.Location = new System.Drawing.Point(30, 270);
            this.Suspend2.Name = "Suspend2";
            this.Suspend2.Size = new System.Drawing.Size(83, 23);
            this.Suspend2.TabIndex = 8;
            this.Suspend2.Text = "Suspend";
            this.Suspend2.UseVisualStyleBackColor = true;
            this.Suspend2.Click += new System.EventHandler(this.Suspend2_Click);
            // 
            // state1
            // 
            this.state1.AutoSize = true;
            this.state1.Location = new System.Drawing.Point(129, 71);
            this.state1.Name = "state1";
            this.state1.Size = new System.Drawing.Size(0, 16);
            this.state1.TabIndex = 11;
            // 
            // state2
            // 
            this.state2.AutoSize = true;
            this.state2.Location = new System.Drawing.Point(129, 212);
            this.state2.Name = "state2";
            this.state2.Size = new System.Drawing.Size(0, 16);
            this.state2.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.state2);
            this.Controls.Add(this.state1);
            this.Controls.Add(this.Abort2);
            this.Controls.Add(this.Resume2);
            this.Controls.Add(this.Suspend2);
            this.Controls.Add(this.Abort1);
            this.Controls.Add(this.Resume1);
            this.Controls.Add(this.Suspend1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Suspend1;
        private System.Windows.Forms.Button Resume1;
        private System.Windows.Forms.Button Abort1;
        private System.Windows.Forms.Button Abort2;
        private System.Windows.Forms.Button Resume2;
        private System.Windows.Forms.Button Suspend2;
        private System.Windows.Forms.Label state1;
        private System.Windows.Forms.Label state2;
    }
}

