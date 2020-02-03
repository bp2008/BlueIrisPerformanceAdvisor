namespace BlueIrisPerformanceAdvisor
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
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.panelActionObjects = new System.Windows.Forms.FlowLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpAdvice = new System.Windows.Forms.TabPage();
			this.tpConfigSummary = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.tpConfigBackups = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.tpSettings = new System.Windows.Forms.TabPage();
			this.cb32on64 = new System.Windows.Forms.CheckBox();
			this.statusStrip1.SuspendLayout();
			this.panelActionObjects.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tpAdvice.SuspendLayout();
			this.tpConfigSummary.SuspendLayout();
			this.tpConfigBackups.SuspendLayout();
			this.tpSettings.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 379);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(554, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblStatus
			// 
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(52, 17);
			this.lblStatus.Text = "lblStatus";
			// 
			// panelActionObjects
			// 
			this.panelActionObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelActionObjects.AutoScroll = true;
			this.panelActionObjects.BackColor = System.Drawing.Color.White;
			this.panelActionObjects.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelActionObjects.Controls.Add(this.panel1);
			this.panelActionObjects.Location = new System.Drawing.Point(0, 0);
			this.panelActionObjects.Name = "panelActionObjects";
			this.panelActionObjects.Size = new System.Drawing.Size(542, 352);
			this.panelActionObjects.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.progressBar1);
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(451, 80);
			this.panel1.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 53);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(368, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "This may take 10-15 seconds in order to get an accurate CPU measurement.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Loading …";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(3, 24);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(445, 23);
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progressBar1.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tpAdvice);
			this.tabControl1.Controls.Add(this.tpConfigSummary);
			this.tabControl1.Controls.Add(this.tpConfigBackups);
			this.tabControl1.Controls.Add(this.tpSettings);
			this.tabControl1.Location = new System.Drawing.Point(2, 2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(550, 377);
			this.tabControl1.TabIndex = 3;
			// 
			// tpAdvice
			// 
			this.tpAdvice.BackColor = System.Drawing.Color.White;
			this.tpAdvice.Controls.Add(this.panelActionObjects);
			this.tpAdvice.Location = new System.Drawing.Point(4, 22);
			this.tpAdvice.Name = "tpAdvice";
			this.tpAdvice.Padding = new System.Windows.Forms.Padding(3);
			this.tpAdvice.Size = new System.Drawing.Size(542, 351);
			this.tpAdvice.TabIndex = 0;
			this.tpAdvice.Text = "Advice";
			// 
			// tpConfigSummary
			// 
			this.tpConfigSummary.Controls.Add(this.label2);
			this.tpConfigSummary.Location = new System.Drawing.Point(4, 22);
			this.tpConfigSummary.Name = "tpConfigSummary";
			this.tpConfigSummary.Padding = new System.Windows.Forms.Padding(3);
			this.tpConfigSummary.Size = new System.Drawing.Size(462, 351);
			this.tpConfigSummary.TabIndex = 1;
			this.tpConfigSummary.Text = "Configuration Summary";
			this.tpConfigSummary.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(31, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(140, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "This feature is not yet ready.";
			// 
			// tpConfigBackups
			// 
			this.tpConfigBackups.Controls.Add(this.label1);
			this.tpConfigBackups.Location = new System.Drawing.Point(4, 22);
			this.tpConfigBackups.Name = "tpConfigBackups";
			this.tpConfigBackups.Padding = new System.Windows.Forms.Padding(3);
			this.tpConfigBackups.Size = new System.Drawing.Size(462, 351);
			this.tpConfigBackups.TabIndex = 2;
			this.tpConfigBackups.Text = "Configuration Backups";
			this.tpConfigBackups.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(140, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "This feature is not yet ready.";
			// 
			// tpSettings
			// 
			this.tpSettings.BackColor = System.Drawing.Color.Transparent;
			this.tpSettings.Controls.Add(this.cb32on64);
			this.tpSettings.Location = new System.Drawing.Point(4, 22);
			this.tpSettings.Name = "tpSettings";
			this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
			this.tpSettings.Size = new System.Drawing.Size(462, 351);
			this.tpSettings.TabIndex = 3;
			this.tpSettings.Text = "Advisor Settings";
			this.tpSettings.UseVisualStyleBackColor = true;
			// 
			// cb32on64
			// 
			this.cb32on64.AutoSize = true;
			this.cb32on64.Location = new System.Drawing.Point(6, 6);
			this.cb32on64.Name = "cb32on64";
			this.cb32on64.Size = new System.Drawing.Size(320, 17);
			this.cb32on64.TabIndex = 0;
			this.cb32on64.Text = "Check this if you are running 32 bit Blue Iris on 64 bit Windows";
			this.cb32on64.UseVisualStyleBackColor = true;
			this.cb32on64.CheckedChanged += new System.EventHandler(this.SettingChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(554, 401);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusStrip1);
			this.Name = "MainForm";
			this.Text = "Blue Iris Performance Advisor";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.panelActionObjects.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tpAdvice.ResumeLayout(false);
			this.tpConfigSummary.ResumeLayout(false);
			this.tpConfigSummary.PerformLayout();
			this.tpConfigBackups.ResumeLayout(false);
			this.tpConfigBackups.PerformLayout();
			this.tpSettings.ResumeLayout(false);
			this.tpSettings.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.FlowLayoutPanel panelActionObjects;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpAdvice;
		private System.Windows.Forms.TabPage tpConfigSummary;
		private System.Windows.Forms.TabPage tpConfigBackups;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tpSettings;
		private System.Windows.Forms.CheckBox cb32on64;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}

