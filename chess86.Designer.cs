namespace chess86
{
    partial class chess86
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chess86));
            this.btnServer = new System.Windows.Forms.Button();
            this.btnClient = new System.Windows.Forms.Button();
            this.chat = new System.Windows.Forms.TextBox();
            this.textBoxM = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.labelYou = new System.Windows.Forms.Label();
            this.labelOpponent = new System.Windows.Forms.Label();
            this.timeYou = new System.Windows.Forms.Label();
            this.timeOpponent = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.textBoxRecord = new System.Windows.Forms.TextBox();
            this.btnResign = new System.Windows.Forms.Button();
            this.btnDraw = new System.Windows.Forms.Button();
            this.textBest = new System.Windows.Forms.Label();
            this.textMark = new System.Windows.Forms.Label();
            this.textDepth = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelRight.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnServer
            // 
            this.btnServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnServer.Location = new System.Drawing.Point(4, 5);
            this.btnServer.Margin = new System.Windows.Forms.Padding(4);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(115, 40);
            this.btnServer.TabIndex = 0;
            this.btnServer.Text = "Вызов";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // btnClient
            // 
            this.btnClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClient.Location = new System.Drawing.Point(4, 52);
            this.btnClient.Margin = new System.Windows.Forms.Padding(4);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(115, 41);
            this.btnClient.TabIndex = 1;
            this.btnClient.Text = "Играть";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // chat
            // 
            this.chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chat.Location = new System.Drawing.Point(4, 4);
            this.chat.Margin = new System.Windows.Forms.Padding(4);
            this.chat.Multiline = true;
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(339, 429);
            this.chat.TabIndex = 2;
            // 
            // textBoxM
            // 
            this.textBoxM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxM.Location = new System.Drawing.Point(4, 446);
            this.textBoxM.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxM.Name = "textBoxM";
            this.textBoxM.Size = new System.Drawing.Size(236, 34);
            this.textBoxM.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(248, 445);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(95, 35);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxIP
            // 
            this.textBoxIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxIP.Location = new System.Drawing.Point(126, 52);
            this.textBoxIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(217, 38);
            this.textBoxIP.TabIndex = 5;
            // 
            // labelYou
            // 
            this.labelYou.AutoSize = true;
            this.labelYou.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelYou.Location = new System.Drawing.Point(4, 60);
            this.labelYou.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelYou.Name = "labelYou";
            this.labelYou.Size = new System.Drawing.Size(58, 31);
            this.labelYou.TabIndex = 6;
            this.labelYou.Text = "you";
            // 
            // labelOpponent
            // 
            this.labelOpponent.AutoSize = true;
            this.labelOpponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOpponent.Location = new System.Drawing.Point(4, 9);
            this.labelOpponent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOpponent.Name = "labelOpponent";
            this.labelOpponent.Size = new System.Drawing.Size(127, 31);
            this.labelOpponent.TabIndex = 7;
            this.labelOpponent.Text = "opponent";
            // 
            // timeYou
            // 
            this.timeYou.AutoSize = true;
            this.timeYou.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeYou.Location = new System.Drawing.Point(201, 53);
            this.timeYou.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeYou.Name = "timeYou";
            this.timeYou.Size = new System.Drawing.Size(83, 39);
            this.timeYou.TabIndex = 8;
            this.timeYou.Text = "3:00";
            // 
            // timeOpponent
            // 
            this.timeOpponent.AutoSize = true;
            this.timeOpponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeOpponent.Location = new System.Drawing.Point(201, 1);
            this.timeOpponent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeOpponent.Name = "timeOpponent";
            this.timeOpponent.Size = new System.Drawing.Size(83, 39);
            this.timeOpponent.TabIndex = 9;
            this.timeOpponent.Text = "3:00";
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.Controls.Add(this.btnRecord);
            this.panelRight.Controls.Add(this.btnStart);
            this.panelRight.Controls.Add(this.textBoxRecord);
            this.panelRight.Controls.Add(this.btnResign);
            this.panelRight.Controls.Add(this.btnDraw);
            this.panelRight.Controls.Add(this.labelOpponent);
            this.panelRight.Controls.Add(this.timeOpponent);
            this.panelRight.Controls.Add(this.labelYou);
            this.panelRight.Controls.Add(this.timeYou);
            this.panelRight.Location = new System.Drawing.Point(1045, 12);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(397, 479);
            this.panelRight.TabIndex = 10;
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStatistics.BackgroundImage")));
            this.btnStatistics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStatistics.Location = new System.Drawing.Point(284, 19);
            this.btnStatistics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(93, 86);
            this.btnStatistics.TabIndex = 19;
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRecord.BackgroundImage")));
            this.btnRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecord.Location = new System.Drawing.Point(283, 368);
            this.btnRecord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(93, 86);
            this.btnRecord.TabIndex = 18;
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.Location = new System.Drawing.Point(283, 277);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(93, 86);
            this.btnStart.TabIndex = 17;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBoxRecord
            // 
            this.textBoxRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRecord.Location = new System.Drawing.Point(11, 95);
            this.textBoxRecord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxRecord.Multiline = true;
            this.textBoxRecord.Name = "textBoxRecord";
            this.textBoxRecord.ReadOnly = true;
            this.textBoxRecord.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRecord.Size = new System.Drawing.Size(253, 365);
            this.textBoxRecord.TabIndex = 16;
            // 
            // btnResign
            // 
            this.btnResign.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnResign.BackgroundImage")));
            this.btnResign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnResign.Location = new System.Drawing.Point(283, 186);
            this.btnResign.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnResign.Name = "btnResign";
            this.btnResign.Size = new System.Drawing.Size(93, 86);
            this.btnResign.TabIndex = 15;
            this.btnResign.UseVisualStyleBackColor = true;
            this.btnResign.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDraw
            // 
            this.btnDraw.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDraw.BackgroundImage")));
            this.btnDraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDraw.Location = new System.Drawing.Point(283, 95);
            this.btnDraw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(93, 86);
            this.btnDraw.TabIndex = 14;
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // textBest
            // 
            this.textBest.AutoSize = true;
            this.textBest.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBest.Location = new System.Drawing.Point(14, 73);
            this.textBest.Name = "textBest";
            this.textBest.Size = new System.Drawing.Size(133, 32);
            this.textBest.TabIndex = 13;
            this.textBest.Text = "Лучший: ";
            // 
            // textMark
            // 
            this.textMark.AutoSize = true;
            this.textMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textMark.Location = new System.Drawing.Point(14, 9);
            this.textMark.Name = "textMark";
            this.textMark.Size = new System.Drawing.Size(130, 32);
            this.textMark.TabIndex = 12;
            this.textMark.Text = "Оценка: ";
            // 
            // textDepth
            // 
            this.textDepth.AutoSize = true;
            this.textDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textDepth.Location = new System.Drawing.Point(14, 41);
            this.textDepth.Name = "textDepth";
            this.textDepth.Size = new System.Drawing.Size(140, 32);
            this.textDepth.TabIndex = 11;
            this.textDepth.Text = "Глубина: ";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.textDepth);
            this.panel1.Controls.Add(this.btnStatistics);
            this.panel1.Controls.Add(this.textMark);
            this.panel1.Controls.Add(this.textBest);
            this.panel1.Location = new System.Drawing.Point(1045, 498);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 119);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnServer);
            this.panel2.Controls.Add(this.btnClient);
            this.panel2.Controls.Add(this.textBoxIP);
            this.panel2.Location = new System.Drawing.Point(5, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 124);
            this.panel2.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.chat);
            this.panel3.Controls.Add(this.textBoxM);
            this.panel3.Controls.Add(this.btnSend);
            this.panel3.Location = new System.Drawing.Point(5, 138);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(351, 487);
            this.panel3.TabIndex = 22;
            // 
            // chess86
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1459, 629);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelRight);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "chess86";
            this.Text = "chess86";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.chess86_FormClosed);
            this.Load += new System.EventHandler(this.chess86_Load);
            this.ResizeEnd += new System.EventHandler(this.chess86_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.chess86_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chess86_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chess86_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chess86_MouseUp);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.TextBox chat;
        private System.Windows.Forms.TextBox textBoxM;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label labelYou;
        private System.Windows.Forms.Label labelOpponent;
        private System.Windows.Forms.Label timeYou;
        private System.Windows.Forms.Label timeOpponent;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label textDepth;
        private System.Windows.Forms.Label textBest;
        private System.Windows.Forms.Label textMark;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnResign;
        private System.Windows.Forms.TextBox textBoxRecord;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}

