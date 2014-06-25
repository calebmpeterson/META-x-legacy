/*
 * Date: 1/14/2013
 * Time: 11:01 PM
 */
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace UI
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MetaX.UI.CommandForm());
		}
		
	}
}
