namespace Client.View
{
    partial class Menu
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
            this.components = new System.ComponentModel.Container();
            this.rtbBroad = new System.Windows.Forms.RichTextBox();
            this.txtchat = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsbLive = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lsbOnline = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbBroad
            // 
            this.rtbBroad.Location = new System.Drawing.Point(12, 45);
            this.rtbBroad.Name = "rtbBroad";
            this.rtbBroad.ReadOnly = true;
            this.rtbBroad.Size = new System.Drawing.Size(398, 328);
            this.rtbBroad.TabIndex = 0;
            this.rtbBroad.TabStop = false;
            this.rtbBroad.Text = "";
            // 
            // txtchat
            // 
            this.txtchat.Location = new System.Drawing.Point(53, 383);
            this.txtchat.Multiline = true;
            this.txtchat.Name = "txtchat";
            this.txtchat.Size = new System.Drawing.Size(276, 33);
            this.txtchat.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Chat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Client.Properties.Resources.icon;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Location = new System.Drawing.Point(12, 381);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 35);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsbLive);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(429, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 133);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Live";
            // 
            // lsbLive
            // 
            this.lsbLive.ContextMenuStrip = this.contextMenuStrip2;
            this.lsbLive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbLive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbLive.FormattingEnabled = true;
            this.lsbLive.Items.AddRange(new object[] {
            "Dương Thần VS Hanhyoki"});
            this.lsbLive.Location = new System.Drawing.Point(3, 19);
            this.lsbLive.Name = "lsbLive";
            this.lsbLive.Size = new System.Drawing.Size(200, 111);
            this.lsbLive.TabIndex = 0;
            this.lsbLive.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsbOnline);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(429, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 189);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Online";
            // 
            // lsbOnline
            // 
            this.lsbOnline.ContextMenuStrip = this.contextMenuStrip1;
            this.lsbOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbOnline.FormattingEnabled = true;
            this.lsbOnline.Items.AddRange(new object[] {
            "Duong",
            "Than",
            "Hanhyoki"});
            this.lsbOnline.Location = new System.Drawing.Point(3, 19);
            this.lsbOnline.Name = "lsbOnline";
            this.lsbOnline.Size = new System.Drawing.Size(200, 167);
            this.lsbOnline.TabIndex = 0;
            this.lsbOnline.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "challenge";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Chat room";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(536, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 27);
            this.button3.TabIndex = 3;
            this.button3.Text = "Log out";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLiveToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(125, 26);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // showLiveToolStripMenuItem
            // 
            this.showLiveToolStripMenuItem.Name = "showLiveToolStripMenuItem";
            this.showLiveToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.showLiveToolStripMenuItem.Text = "Show live";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 433);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtchat);
            this.Controls.Add(this.rtbBroad);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbBroad;
        private System.Windows.Forms.TextBox txtchat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lsbLive;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lsbOnline;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem showLiveToolStripMenuItem;
    }
}