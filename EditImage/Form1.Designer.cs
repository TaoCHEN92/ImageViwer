namespace EditImage
{
    partial class ImageViwer
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
            this.btOpenImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbHeightImg = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btRotateImg = new System.Windows.Forms.PictureBox();
            this.btLastImg = new System.Windows.Forms.PictureBox();
            this.btNextImg = new System.Windows.Forms.PictureBox();
            this.lbWidthImg = new System.Windows.Forms.Label();
            this.btSaveImg = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btRotateImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btLastImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btNextImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btOpenImage
            // 
            this.btOpenImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btOpenImage.BackColor = System.Drawing.Color.White;
            this.btOpenImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btOpenImage.FlatAppearance.BorderSize = 0;
            this.btOpenImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btOpenImage.Location = new System.Drawing.Point(11, 7);
            this.btOpenImage.Name = "btOpenImage";
            this.btOpenImage.Size = new System.Drawing.Size(75, 23);
            this.btOpenImage.TabIndex = 0;
            this.btOpenImage.Text = "Open Image";
            this.btOpenImage.UseVisualStyleBackColor = false;
            this.btOpenImage.Click += new System.EventHandler(this.btOpenImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(310, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Height :";
            // 
            // lbHeightImg
            // 
            this.lbHeightImg.AutoSize = true;
            this.lbHeightImg.Location = new System.Drawing.Point(360, 12);
            this.lbHeightImg.Name = "lbHeightImg";
            this.lbHeightImg.Size = new System.Drawing.Size(0, 13);
            this.lbHeightImg.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(417, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Width :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btRotateImg);
            this.panel1.Controls.Add(this.btLastImg);
            this.panel1.Controls.Add(this.btNextImg);
            this.panel1.Controls.Add(this.lbWidthImg);
            this.panel1.Controls.Add(this.btSaveImg);
            this.panel1.Controls.Add(this.btOpenImage);
            this.panel1.Controls.Add(this.lbHeightImg);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 38);
            this.panel1.TabIndex = 7;
            // 
            // btRotateImg
            // 
            this.btRotateImg.BackgroundImage = global::EditImage.Properties.Resources.Auto_rotate_Android;
            this.btRotateImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btRotateImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRotateImg.Location = new System.Drawing.Point(622, 7);
            this.btRotateImg.Name = "btRotateImg";
            this.btRotateImg.Size = new System.Drawing.Size(28, 23);
            this.btRotateImg.TabIndex = 13;
            this.btRotateImg.TabStop = false;
            this.btRotateImg.Click += new System.EventHandler(this.btRotateImg_Click);
            // 
            // btLastImg
            // 
            this.btLastImg.BackgroundImage = global::EditImage.Properties.Resources.Arrow_Left;
            this.btLastImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btLastImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btLastImg.Location = new System.Drawing.Point(554, 7);
            this.btLastImg.Name = "btLastImg";
            this.btLastImg.Size = new System.Drawing.Size(28, 23);
            this.btLastImg.TabIndex = 12;
            this.btLastImg.TabStop = false;
            this.btLastImg.Click += new System.EventHandler(this.btLastImg_Click);
            // 
            // btNextImg
            // 
            this.btNextImg.BackgroundImage = global::EditImage.Properties.Resources.Arrow_Right;
            this.btNextImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btNextImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNextImg.Location = new System.Drawing.Point(588, 7);
            this.btNextImg.Name = "btNextImg";
            this.btNextImg.Size = new System.Drawing.Size(28, 23);
            this.btNextImg.TabIndex = 11;
            this.btNextImg.TabStop = false;
            this.btNextImg.Click += new System.EventHandler(this.btNextImg_Click);
            // 
            // lbWidthImg
            // 
            this.lbWidthImg.AutoSize = true;
            this.lbWidthImg.Location = new System.Drawing.Point(465, 12);
            this.lbWidthImg.Name = "lbWidthImg";
            this.lbWidthImg.Size = new System.Drawing.Size(0, 13);
            this.lbWidthImg.TabIndex = 10;
            // 
            // btSaveImg
            // 
            this.btSaveImg.BackColor = System.Drawing.Color.White;
            this.btSaveImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btSaveImg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSaveImg.Location = new System.Drawing.Point(93, 7);
            this.btSaveImg.Name = "btSaveImg";
            this.btSaveImg.Size = new System.Drawing.Size(75, 23);
            this.btSaveImg.TabIndex = 8;
            this.btSaveImg.Text = "Save Image";
            this.btSaveImg.UseVisualStyleBackColor = false;
            this.btSaveImg.Click += new System.EventHandler(this.btSaveImg_Click);
            // 
            // pbImage
            // 
            this.pbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage.Location = new System.Drawing.Point(0, 0);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(707, 373);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 1;
            this.pbImage.TabStop = false;
            this.pbImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseDown);
            this.pbImage.MouseEnter += new System.EventHandler(this.pbImage_MouseEnter_1);
            this.pbImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseMove);
            this.pbImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseUp);
            this.pbImage.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseWheel);
            // 
            // EditImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(707, 373);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbImage);
            this.Name = "EditImage";
            this.Text = "超级厉害的图像查看器";
            this.Resize += new System.EventHandler(this.EditImage_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btRotateImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btLastImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btNextImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOpenImage;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbHeightImg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btSaveImg;
        private System.Windows.Forms.Label lbWidthImg;
        private System.Windows.Forms.PictureBox btNextImg;
        private System.Windows.Forms.PictureBox btLastImg;
        private System.Windows.Forms.PictureBox btRotateImg;
    }
}

