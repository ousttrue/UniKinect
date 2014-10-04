namespace SampleForm
{
    partial class Form1
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.sensors = new System.Windows.Forms.ListBox();
            this.sensorControl1 = new SampleForm.SensorControl();
            this.SuspendLayout();
            // 
            // sensors
            // 
            this.sensors.FormattingEnabled = true;
            this.sensors.ItemHeight = 12;
            this.sensors.Location = new System.Drawing.Point(12, 12);
            this.sensors.Name = "sensors";
            this.sensors.Size = new System.Drawing.Size(389, 88);
            this.sensors.TabIndex = 0;
            this.sensors.SelectedIndexChanged += new System.EventHandler(this.sensors_SelectedIndexChanged);
            // 
            // sensorControl1
            // 
            this.sensorControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sensorControl1.Location = new System.Drawing.Point(12, 106);
            this.sensorControl1.MaxDepth = 1;
            this.sensorControl1.Name = "sensorControl1";
            this.sensorControl1.Sensor = null;
            this.sensorControl1.Size = new System.Drawing.Size(924, 434);
            this.sensorControl1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 552);
            this.Controls.Add(this.sensorControl1);
            this.Controls.Add(this.sensors);
            this.Name = "Form1";
            this.Text = "UniKinectForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox sensors;
        private SensorControl sensorControl1;


    }
}

