using BlueIrisPerformanceAdvisor.Advice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueIrisPerformanceAdvisor
{
	public partial class MainForm : Form
	{
		Advisor advisor = new Advisor();
		List<AdviceBase> advice = new List<AdviceBase>();
		public MainForm()
		{
			InitializeComponent();
			Text += " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
			this.lblStatus.Text = "";
			advisor.AdviceReady += Advisor_AdviceReady;
			LoadSettingsIntoGUI();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			this.lblStatus.Text = "Loading Blue Iris Configuration";
			advisor.GenerateAdvice();
		}

		#region Tab: "Advice"
		private void Advisor_AdviceReady(object sender, List<AdviceBase> advice)
		{
			if (this.InvokeRequired)
				this.Invoke((Action<object, List<AdviceBase>>)Advisor_AdviceReady, sender, advice);
			else
			{
				this.advice = advice;
				this.lblStatus.Text = "";
				panelActionObjects.Controls.Clear();
				if (advice == null)
				{
					Label lblFailed = new Label();
					lblFailed.AutoSize = true;
					this.lblStatus.Text = lblFailed.Text = advisor.error;
					panelActionObjects.Controls.Add(lblFailed);
					return;
				}
				foreach (AdviceBase adviceItem in this.advice)
				{
					ActionableObject ao = new ActionableObject(adviceItem.name, adviceItem.GetDescription());

					string learnMoreText = adviceItem.LearnMore();
					if (!string.IsNullOrWhiteSpace(learnMoreText))
					{
						ao.OnLearnMoreClicked += (ignored1, ignored2) =>
						{
							MessageBox.Show(learnMoreText);
						};
						ao.ShowLearnMore = true;
					}
					else
						ao.ShowLearnMore = false;

					ao.OnFixMeClicked += (ignored1, ignored2) =>
					{
						adviceItem.Fix();
						RemoveActionableObject(ao);
					};

					panelActionObjects.Controls.Add(ao);
				}
			}
		}

		private void RemoveActionableObject(ActionableObject ao)
		{
			if (this.InvokeRequired)
				this.Invoke((Action<ActionableObject>)RemoveActionableObject, ao);
			else
			{
				panelActionObjects.Controls.Remove(ao);
			}
		}
		#endregion

		#region Tab: "Advisor Settings"
		private void LoadSettingsIntoGUI()
		{
			this.cb32on64.Checked = Program.settings.bi32OnWin64;
		}
		private void SettingChanged(object sender, EventArgs e)
		{
			Program.settings.bi32OnWin64 = this.cb32on64.Checked;
			Program.settings.Save();
		}
		#endregion
	}
}
