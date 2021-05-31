namespace chess86
{
    partial class Form8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            this.pictureQ = new System.Windows.Forms.PictureBox();
            this.pictureR = new System.Windows.Forms.PictureBox();
            this.pictureB = new System.Windows.Forms.PictureBox();
            this.pictureN = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureN)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureQ
            // 
            this.pictureQ.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureQ.BackgroundImage")));
            this.pictureQ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureQ.Location = new System.Drawing.Point(10, 10);
            this.pictureQ.Name = "pictureQ";
            this.pictureQ.Size = new System.Drawing.Size(80, 80);
            this.pictureQ.TabIndex = 0;
            this.pictureQ.TabStop = false;
            this.pictureQ.Click += new System.EventHandler(this.pictureQ_Click);
            // 
            // pictureR
            // 
            this.pictureR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureR.BackgroundImage")));
            this.pictureR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureR.Location = new System.Drawing.Point(100, 10);
            this.pictureR.Name = "pictureR";
            this.pictureR.Size = new System.Drawing.Size(80, 80);
            this.pictureR.TabIndex = 1;
            this.pictureR.TabStop = false;
            this.pictureR.Click += new System.EventHandler(this.pictureR_Click);
            // 
            // pictureB
            // 
            this.pictureB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureB.BackgroundImage")));
            this.pictureB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureB.Location = new System.Drawing.Point(190, 10);
            this.pictureB.Name = "pictureB";
            this.pictureB.Size = new System.Drawing.Size(80, 80);
            this.pictureB.TabIndex = 2;
            this.pictureB.TabStop = false;
            this.pictureB.Click += new System.EventHandler(this.pictureB_Click);
            // 
            // pictureN
            // 
            this.pictureN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureN.BackgroundImage")));
            this.pictureN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureN.Location = new System.Drawing.Point(280, 10);
            this.pictureN.Name = "pictureN";
            this.pictureN.Size = new System.Drawing.Size(80, 80);
            this.pictureN.TabIndex = 3;
            this.pictureN.TabStop = false;
            this.pictureN.Click += new System.EventHandler(this.pictureN_Click);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(369, 100);
            this.Controls.Add(this.pictureN);
            this.Controls.Add(this.pictureB);
            this.Controls.Add(this.pictureR);
            this.Controls.Add(this.pictureQ);
            this.Name = "Form8";
            this.Text = "Ну выбирай";
            ((System.ComponentModel.ISupportInitialize)(this.pictureQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureQ;
        private System.Windows.Forms.PictureBox pictureR;
        private System.Windows.Forms.PictureBox pictureB;
        private System.Windows.Forms.PictureBox pictureN;
    }
}