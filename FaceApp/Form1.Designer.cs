namespace FaceApp
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileName1 = new System.Windows.Forms.TextBox();
            this.txtFaceInfo1 = new System.Windows.Forms.TextBox();
            this.txtFaceInfo2 = new System.Windows.Forms.TextBox();
            this.txtFileName2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cmdVerifyFaces = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(548, 316);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(444, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Face Information:";
            // 
            // txtFileName1
            // 
            this.txtFileName1.Location = new System.Drawing.Point(12, 351);
            this.txtFileName1.Name = "txtFileName1";
            this.txtFileName1.Size = new System.Drawing.Size(416, 22);
            this.txtFileName1.TabIndex = 4;
            // 
            // txtFaceInfo1
            // 
            this.txtFaceInfo1.Location = new System.Drawing.Point(12, 419);
            this.txtFaceInfo1.Multiline = true;
            this.txtFaceInfo1.Name = "txtFaceInfo1";
            this.txtFaceInfo1.Size = new System.Drawing.Size(548, 175);
            this.txtFaceInfo1.TabIndex = 5;
            // 
            // txtFaceInfo2
            // 
            this.txtFaceInfo2.Location = new System.Drawing.Point(591, 419);
            this.txtFaceInfo2.Multiline = true;
            this.txtFaceInfo2.Name = "txtFaceInfo2";
            this.txtFaceInfo2.Size = new System.Drawing.Size(548, 175);
            this.txtFaceInfo2.TabIndex = 10;
            // 
            // txtFileName2
            // 
            this.txtFileName2.Location = new System.Drawing.Point(591, 351);
            this.txtFileName2.Name = "txtFileName2";
            this.txtFileName2.Size = new System.Drawing.Size(416, 22);
            this.txtFileName2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(591, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "Face Information:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1023, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 24);
            this.button2.TabIndex = 7;
            this.button2.Text = "Select Image";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(591, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(548, 316);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // cmdVerifyFaces
            // 
            this.cmdVerifyFaces.Location = new System.Drawing.Point(14, 615);
            this.cmdVerifyFaces.Name = "cmdVerifyFaces";
            this.cmdVerifyFaces.Size = new System.Drawing.Size(1125, 24);
            this.cmdVerifyFaces.TabIndex = 11;
            this.cmdVerifyFaces.Text = "Verify faces";
            this.cmdVerifyFaces.UseVisualStyleBackColor = true;
            this.cmdVerifyFaces.Click += new System.EventHandler(this.cmdVerifyFaces_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 660);
            this.Controls.Add(this.cmdVerifyFaces);
            this.Controls.Add(this.txtFaceInfo2);
            this.Controls.Add(this.txtFileName2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtFaceInfo1);
            this.Controls.Add(this.txtFileName1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileName1;
        private System.Windows.Forms.TextBox txtFaceInfo1;
        private System.Windows.Forms.TextBox txtFaceInfo2;
        private System.Windows.Forms.TextBox txtFileName2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button cmdVerifyFaces;
    }
}

