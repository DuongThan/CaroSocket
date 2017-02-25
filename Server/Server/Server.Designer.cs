namespace Server
{
    partial class Server
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
            this.LsbConnect = new System.Windows.Forms.ListBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LsbConnect
            // 
            this.LsbConnect.FormattingEnabled = true;
            this.LsbConnect.Items.AddRange(new object[] {
            "Waiting for connection"});
            this.LsbConnect.Location = new System.Drawing.Point(12, 12);
            this.LsbConnect.Name = "LsbConnect";
            this.LsbConnect.Size = new System.Drawing.Size(340, 303);
            this.LsbConnect.TabIndex = 0;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(143, 321);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(65, 26);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 359);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.LsbConnect);
            this.Name = "Server";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LsbConnect;
        private System.Windows.Forms.Button btnQuit;
    }
}

