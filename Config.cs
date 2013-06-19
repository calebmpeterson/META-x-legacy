/*
 * Date: 5/27/2013
 * Time: 11:45 AM
 */
using System;
using System.Drawing;

namespace Xel.UI
{
	/// <summary>
	/// Configuration.
	/// </summary>
	public class Config
	{
		public Config()
		{
			this.EndpointBaseURL = "http://localhost:3000";
			this.EndpointExecute = "/!";
			this.EndpointResource = "/api/v1";
			
			this.BackColor = ColorTranslator.FromHtml("#002B36");
			this.ForeColor = ColorTranslator.FromHtml("#FDF6E3");
		}
		
		public String EndpointBaseURL { get; set; }
		public String EndpointExecute { get; set; }
		public String EndpointResource { get; set; }
		
		public Color BackColor { get; set; }
		public Color ForeColor { get; set; }
		
	}
}
