namespace BlueIrisPerformanceAdvisor
{
	partial class ActionableObject
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnFix = new System.Windows.Forms.Button();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnLearnMore = new System.Windows.Forms.LinkLabel();
			this.lblDescription = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnFix
			// 
			this.btnFix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFix.BackColor = System.Drawing.Color.Lime;
			this.btnFix.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFix.Location = new System.Drawing.Point(330, 27);
			this.btnFix.Name = "btnFix";
			this.btnFix.Size = new System.Drawing.Size(97, 50);
			this.btnFix.TabIndex = 4;
			this.btnFix.Text = "Fix Me";
			this.btnFix.UseVisualStyleBackColor = false;
			this.btnFix.Click += new System.EventHandler(this.BtnFix_Click);
			// 
			// lblTitle
			// 
			this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTitle.AutoEllipsis = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(3, 1);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(321, 23);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "Title";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnLearnMore
			// 
			this.btnLearnMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLearnMore.AutoEllipsis = true;
			this.btnLearnMore.Location = new System.Drawing.Point(330, 1);
			this.btnLearnMore.Name = "btnLearnMore";
			this.btnLearnMore.Size = new System.Drawing.Size(97, 23);
			this.btnLearnMore.TabIndex = 2;
			this.btnLearnMore.TabStop = true;
			this.btnLearnMore.Text = "Learn More";
			this.btnLearnMore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnLearnMore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnLearnMore_Click);
			// 
			// lblDescription
			// 
			this.lblDescription.AutoEllipsis = true;
			this.lblDescription.BackColor = System.Drawing.SystemColors.Control;
			this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription.Location = new System.Drawing.Point(3, 27);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(321, 50);
			this.lblDescription.TabIndex = 5;
			this.lblDescription.Text = "Description";
			// 
			// ActionableObject
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.btnLearnMore);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.btnFix);
			this.Name = "ActionableObject";
			this.Size = new System.Drawing.Size(430, 80);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btnFix;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.LinkLabel btnLearnMore;
		private System.Windows.Forms.Label lblDescription;
	}
}
