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
            this.pictureBoxForImage = new System.Windows.Forms.PictureBox();
            this.colorImageResolutions = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBoxForDepth = new System.Windows.Forms.PictureBox();
            this.depthResolutions = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.maxDepth = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxForImage);
            this.groupBox1.Controls.Add(this.colorImageResolutions);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 480);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ImageStream";
            // 
            // pictureBoxForImage
            // 
            this.pictureBoxForImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxForImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxForImage.Location = new System.Drawing.Point(6, 112);
            this.pictureBoxForImage.Name = "pictureBoxForImage";
            this.pictureBoxForImage.Size = new System.Drawing.Size(419, 362);
            this.pictureBoxForImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxForImage.TabIndex = 1;
            this.pictureBoxForImage.TabStop = false;
            // 
            // colorImageResolutions
            // 
            this.colorImageResolutions.FormattingEnabled = true;
            this.colorImageResolutions.ItemHeight = 12;
            this.colorImageResolutions.Location = new System.Drawing.Point(6, 18);
            this.colorImageResolutions.Name = "colorImageResolutions";
            this.colorImageResolutions.Size = new System.Drawing.Size(120, 88);
            this.colorImageResolutions.TabIndex = 0;
            this.colorImageResolutions.SelectedIndexChanged += new System.EventHandler(this.colorImageResolutions_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.maxDepth);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.pictureBoxForDepth);
            this.groupBox2.Controls.Add(this.depthResolutions);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 480);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DepthStream";
            // 
            // pictureBoxForDepth
            // 
            this.pictureBoxForDepth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxForDepth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxForDepth.Location = new System.Drawing.Point(6, 112);
            this.pictureBoxForDepth.Name = "pictureBoxForDepth";
            this.pictureBoxForDepth.Size = new System.Drawing.Size(273, 362);
            this.pictureBoxForDepth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxForDepth.TabIndex = 2;
            this.pictureBoxForDepth.TabStop = false;
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(720, 480);
            this.splitContainer1.SplitterDistance = 431;
            this.splitContainer1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "maxDepth";
            // 
            // maxDepth
            // 
            this.maxDepth.Location = new System.Drawing.Point(194, 18);
            this.maxDepth.Name = "maxDepth";
            this.maxDepth.ReadOnly = true;
            this.maxDepth.Size = new System.Drawing.Size(67, 19);
            this.maxDepth.TabIndex = 4;
            this.maxDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SensorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SensorControl";
            this.Size = new System.Drawing.Size(720, 480);
            this.Load += new System.EventHandler(this.SensorControl_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForDepth)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxForImage;
        private System.Windows.Forms.ListBox colorImageResolutions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBoxForDepth;
        private System.Windows.Forms.ListBox depthResolutions;
        private System.Windows.Forms.TextBox maxDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
