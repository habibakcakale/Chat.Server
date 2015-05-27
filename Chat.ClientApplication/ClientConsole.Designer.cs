namespace Chat.ClientApplication
{
    partial class ClientConsole
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
            this.Connect = new System.Windows.Forms.Button();
            this.PortNumber = new System.Windows.Forms.NumericUpDown();
            this.IpAdress = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.UserList = new System.Windows.Forms.ListBox();
            this.GlobalMessages = new System.Windows.Forms.TextBox();
            this.GlobalMessageBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PortNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(334, 12);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 0;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // PortNumber
            // 
            this.PortNumber.Location = new System.Drawing.Point(263, 15);
            this.PortNumber.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.PortNumber.Name = "PortNumber";
            this.PortNumber.Size = new System.Drawing.Size(65, 20);
            this.PortNumber.TabIndex = 1;
            this.PortNumber.Value = new decimal(new int[] {
            9090,
            0,
            0,
            0});
            // 
            // IpAdress
            // 
            this.IpAdress.Location = new System.Drawing.Point(157, 15);
            this.IpAdress.Name = "IpAdress";
            this.IpAdress.Size = new System.Drawing.Size(100, 20);
            this.IpAdress.TabIndex = 2;
            this.IpAdress.Text = "127.0.0.1";
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(157, 41);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(100, 20);
            this.UserName.TabIndex = 3;
            // 
            // UserList
            // 
            this.UserList.FormattingEnabled = true;
            this.UserList.Location = new System.Drawing.Point(12, 15);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(120, 225);
            this.UserList.TabIndex = 4;
            this.UserList.SelectedIndexChanged += new System.EventHandler(this.UserList_SelectedIndexChanged);
            this.UserList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UserList_MouseDoubleClick);
            // 
            // GlobalMessages
            // 
            this.GlobalMessages.Location = new System.Drawing.Point(157, 67);
            this.GlobalMessages.Multiline = true;
            this.GlobalMessages.Name = "GlobalMessages";
            this.GlobalMessages.Size = new System.Drawing.Size(252, 145);
            this.GlobalMessages.TabIndex = 5;
            // 
            // GlobalMessageBox
            // 
            this.GlobalMessageBox.Location = new System.Drawing.Point(157, 219);
            this.GlobalMessageBox.Name = "GlobalMessageBox";
            this.GlobalMessageBox.Size = new System.Drawing.Size(252, 20);
            this.GlobalMessageBox.TabIndex = 6;
            this.GlobalMessageBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GlobalMessageBox_KeyUp);
            // 
            // ClientConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 353);
            this.Controls.Add(this.GlobalMessageBox);
            this.Controls.Add(this.GlobalMessages);
            this.Controls.Add(this.UserList);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.IpAdress);
            this.Controls.Add(this.PortNumber);
            this.Controls.Add(this.Connect);
            this.Name = "ClientConsole";
            this.Text = "ClientConsole";
            ((System.ComponentModel.ISupportInitialize)(this.PortNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.NumericUpDown PortNumber;
        private System.Windows.Forms.TextBox IpAdress;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.ListBox UserList;
        private System.Windows.Forms.TextBox GlobalMessages;
        private System.Windows.Forms.TextBox GlobalMessageBox;
    }
}