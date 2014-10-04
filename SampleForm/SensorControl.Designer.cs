namespace SampleForm
{
    partial class SensorControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.colorImageResolutions = new System.Windows.Forms.ListBox();
            this.pictureBoxForImage = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.depthResolutions = new System.Windows.Forms.ListBox();
            this.pictureBoxForDepth = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pictureBoxForImage);
            this.groupBox1.Controls.Add(this.colorImageResolutions);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 480);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ImageStream";
            // 
            // imageResolutions
            // 
            this.colorImageResolutions.FormattingEnabled = true;
            this.colorImageResolutions.ItemHeight = 12;
            this.colorImageResolutions.Location = new System.Drawing.Point(6, 18);
            this.colorImageResolutions.Name = "imageResolutions";
            this.colorImageResolutions.Size = new System.Drawing.Size(120, 88);
            this.colorImageResolutions.TabIndex = 0;
            this.colorImageResolutions.SelectedIndexChanged += new System.EventHandler(this.colorImageResolutions_SelectedIndexChanged);
            // 
            // pictureBoxForImage
            // 
            this.pictureBoxForImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxForImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxForImage.Location = new System.Drawing.Point(6, 112);
            this.pictureBoxForImage.Name = "pictureBoxForImage";
            this.pictureBoxForImage.Size = new System.Drawing.Size(468, 362);
            this.pictureBoxForImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxForImage.TabIndex = 1;
            this.pictureBoxForImage.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.pictureBoxForDepth);
            this.groupBox2.Controls.Add(this.depthResolutions);
            this.groupBox2.Location = new System.Drawing.Point(480, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 480);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DepthStream";
            // 
            // depthResolutions
            // 
            this.depthResolutions.FormattingEnabled = true;
            this.depthResolutions.ItemHeight = 12;
            this.depthResolutions.Location = new System.Drawing.Point(6, 18);
            this.depthResolutions.Name = "depthResolutions";
            this.depthResolutions.Size = new System.Drawing.Size(120, 88);
            this.depthResolutions.TabIndex = 2;
            this.depthResolutions.SelectedIndexChanged += new System.EventHandler(this.depthResolutions_SelectedIndexChanged);
            // 
            // pictureBoxForDepth
            // 
            this.pictureBoxForDepth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxForDepth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxForDepth.Location = new System.Drawing.Point(6, 112);
            this.pictureBoxForDepth.Name = "pictureBoxForDepth";
            this.pictureBoxForDepth.Size = new System.Drawing.Size(228, 362);
            this.pictureBoxForDepth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxForDepth.TabIndex = 2;
            this.pictureBoxForDepth.TabStop = false;
            // 
            // SensorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SensorControl";
            this.Size = new System.Drawing.Size(720, 480);
            this.Load += new System.EventHandler(this.SensorControl_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForDepth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxForImage;
        private System.Windows.Forms.ListBox colorImageResolutions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBoxForDepth;
        private System.Windows.Forms.ListBox depthResolutions;
    }
}
