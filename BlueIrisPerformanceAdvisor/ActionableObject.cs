using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueIrisPerformanceAdvisor
{
	public partial class ActionableObject : UserControl
	{
		public ActionableObject()
		{
			InitializeComponent();
		}
		public ActionableObject(string title = null, string description = null) : this()
		{
			Title = title;
			Description = description;
		}
		#region Title
		/// <summary>
		/// Gets or sets the title of this object.
		/// </summary>
		public string Title
		{
			get
			{
				return this.lblTitle.Text;
			}
			set
			{
				this.lblTitle.Text = value != null ? value : "";
			}
		}
		#endregion
		#region Description
		/// <summary>
		/// Gets or sets the description of this object.
		/// </summary>
		public string Description
		{
			get
			{
				return this.lblDescription.Text;
			}
			set
			{
				this.lblDescription.Text = value != null ? value : "";
			}
		}
		#endregion
		#region Learn More
		/// <summary>
		/// Event which is raised when the "Learn More" button is clicked.
		/// </summary>
		public event EventHandler OnLearnMoreClicked = delegate { };
		/// <summary>
		/// Controls visibility of the "Learn More" button.
		/// </summary>
		public bool ShowLearnMore
		{
			get
			{
				return btnLearnMore.Visible;
			}
			set
			{
				btnLearnMore.Visible = value;
			}
		}
		private void btnLearnMore_Click(object sender, LinkLabelLinkClickedEventArgs e)
		{
			OnLearnMoreClicked(sender, e);
		}
		#endregion
		#region Fix Me
		/// <summary>
		/// Event which is raised when the "Fix Me" button is clicked.
		/// </summary>
		public event EventHandler OnFixMeClicked = delegate { };
		/// <summary>
		/// Controls visibility of the "Learn More" button.
		/// </summary>
		public bool ShowFixMe
		{
			get
			{
				return btnFix.Visible;
			}
			set
			{
				btnFix.Visible = value;
			}
		}

		private void BtnFix_Click(object sender, EventArgs e)
		{
			OnFixMeClicked(sender, e);
		}
		#endregion
	}
}
