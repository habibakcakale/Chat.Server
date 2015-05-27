namespace Chat.ClientApplication
{
    partial class PrivateChat
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
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.Messages = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(12, 229);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(260, 20);
            this.MessageBox.TabIndex = 0;
            this.MessageBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MessageBox_KeyUp);
            // 
            // Messages
            // 
            this.Messages.Location = new System.Drawing.Point(12, 12);
            this.Messages.Multiline = true;
            this.Messages.Name = "Messages";
            this.Messages.Size = new System.Drawing.Size(260, 211);
            this.Messages.TabIndex = 1;
            // 
            // PrivateChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Messages);
            this.Controls.Add(this.MessageBox);
            this.Name = "PrivateChat";
            this.Text = "PrivateChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.TextBox Messages;
    }
}