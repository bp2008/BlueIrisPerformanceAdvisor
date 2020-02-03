using BlueIrisPerformanceAdvisor.Configuration;
using BPUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueIrisPerformanceAdvisor.Advice
{
	public abstract class AdviceBase
	{
		public readonly BlueIrisConfiguration c;
		public readonly string name;

		public AdviceBase(BlueIrisConfiguration c, string name)
		{
			this.c = c;
			this.name = name;
		}
		/// <summary>
		/// Returns a string describing the advice item.
		/// </summary>
		/// <returns></returns>
		public abstract string GetDescription();
		public abstract string LearnMore();
		protected abstract void FixMe();
		public void Fix()
		{
			Logger.Info("Fixing: " + name);
			FixMe();
		}
		public void Ignore()
		{
			Logger.Info("Ignoring: " + name);
		}
	}
}
