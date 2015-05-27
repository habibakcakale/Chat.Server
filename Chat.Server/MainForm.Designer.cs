namespace Chat.Server
{
    partial class MainForm
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
            this.StartListening = new System.Windows.Forms.Button();
            this.PortNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.PortNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // StartListening
            // 
            this.StartListening.Location = new System.Drawing.Point(200, 12);
            this.StartListening.Name = "StartListening";
            this.StartListening.Size = new System.Drawing.Size(75, 23);
            this.StartListening.TabIndex = 0;
            this.StartListening.Text = "Start";
            this.StartListening.UseVisualStyleBackColor = true;
            this.StartListening.Click += new System.EventHandler(this.StartListening_Click);
            // 
            // PortNumber
            // 
            this.PortNumber.Location = new System.Drawing.Point(115, 12);
            this.PortNumber.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.PortNumber.Name = "PortNumber";
            this.PortNumber.Size = new System.Drawing.Size(70, 20);
            this.PortNumber.TabIndex = 1;
            this.PortNumber.Value = new decimal(new int[] {
            9090,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 262);
            this.Controls.Add(this.PortNumber);
            this.Controls.Add(this.StartListening);
            this.Name = "MainForm";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.PortNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartListening;
        private System.Windows.Forms.NumericUpDown PortNumber;
    }
}