namespace Telegram_Bot_Test
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
            this.richTextBoxData = new System.Windows.Forms.RichTextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.backgroundWorkerProcess = new System.ComponentModel.BackgroundWorker();
            this.buttonAnekdot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxData
            // 
            this.richTextBoxData.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxData.Name = "richTextBoxData";
            this.richTextBoxData.Size = new System.Drawing.Size(313, 96);
            this.richTextBoxData.TabIndex = 0;
            this.richTextBoxData.Text = "";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 114);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(72, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // backgroundWorkerProcess
            // 
            this.backgroundWorkerProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerProcess_DoWorkAsync);
            // 
            // buttonAnekdot
            // 
            this.buttonAnekdot.Location = new System.Drawing.Point(90, 114);
            this.buttonAnekdot.Name = "buttonAnekdot";
            this.buttonAnekdot.Size = new System.Drawing.Size(75, 23);
            this.buttonAnekdot.TabIndex = 2;
            this.buttonAnekdot.Text = "Anekdot";
            this.buttonAnekdot.UseVisualStyleBackColor = true;
            this.buttonAnekdot.Click += new System.EventHandler(this.buttonAnekdot_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 149);
            this.Controls.Add(this.buttonAnekdot);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.richTextBoxData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxData;
        private System.Windows.Forms.Button buttonStart;
        private System.ComponentModel.BackgroundWorker backgroundWorkerProcess;
        private System.Windows.Forms.Button buttonAnekdot;
    }
}

