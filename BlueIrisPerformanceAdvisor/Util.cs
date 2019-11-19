using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueIrisPerformanceAdvisor
{
	public static class Util
	{
		/// <summary>
		/// Returns number == 1 ? "" : "s"
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public static string s(int number)
		{
			return number == 1 ? "" : "s";
		}
	}
}
