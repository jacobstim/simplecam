namespace MyWebCam
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimalisticStyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.maintainAspectRatioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToFitWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resolutionBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 336);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(448, 24);
            this.menuStrip1.TabIndex = 1;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem3.Text = "&About...";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.aboutWindow);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem4.Text = "E&xit";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.exitProgram);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alwaysOnTopToolStripMenuItem,
            this.minimalisticStyleToolStripMenuItem,
            this.toolStripSeparator1,
            this.maintainAspectRatioToolStripMenuItem,
            this.scaleToFitWindowToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItem2.Text = "Settings";
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "Always On Top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.toggleAlwaysOnTop);
            // 
            // minimalisticStyleToolStripMenuItem
            // 
            this.minimalisticStyleToolStripMenuItem.Name = "minimalisticStyleToolStripMenuItem";
            this.minimalisticStyleToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.minimalisticStyleToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.minimalisticStyleToolStripMenuItem.Text = "Minimalist Mode";
            this.minimalisticStyleToolStripMenuItem.Click += new System.EventHandler(this.toggleWindowStyle);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // maintainAspectRatioToolStripMenuItem
            // 
            this.maintainAspectRatioToolStripMenuItem.Name = "maintainAspectRatioToolStripMenuItem";
            this.maintainAspectRatioToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.maintainAspectRatioToolStripMenuItem.Text = "Maintain Aspect Ratio";
            this.maintainAspectRatioToolStripMenuItem.Click += new System.EventHandler(this.toggleAspectRatio);
            // 
            // scaleToFitWindowToolStripMenuItem
            // 
            this.scaleToFitWindowToolStripMenuItem.Name = "scaleToFitWindowToolStripMenuItem";
            this.scaleToFitWindowToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.scaleToFitWindowToolStripMenuItem.Text = "Scale to Fit Window";
            this.scaleToFitWindowToolStripMenuItem.Click += new System.EventHandler(this.toggleScaleToFit);
            // 
            // resolutionBox
            // 
            this.resolutionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resolutionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resolutionBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resolutionBox.FormattingEnabled = true;
            this.resolutionBox.Location = new System.Drawing.Point(315, 328);
            this.resolutionBox.Name = "resolutionBox";
            this.resolutionBox.Size = new System.Drawing.Size(121, 21);
            this.resolutionBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(448, 361);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.resolutionBox);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SimpleCam v1.1 - Tim Jacobs";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Resize += new System.EventHandler(this.Form1_ResizeEnd);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimalisticStyleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintainAspectRatioToolStripMenuItem;
        private System.Windows.Forms.ComboBox resolutionBox;
        private System.Windows.Forms.ToolStripMenuItem scaleToFitWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

