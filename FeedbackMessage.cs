/*
 * Date: 6/30/2013
 * Time: 1:17 AM
 */
using System;
using System.Text;

namespace Xel.UI
{
	/// <summary>
	/// Description of FeedbackMessage.
	/// </summary>
	public class FeedbackMessage
	{
		public readonly String content;
		
		public FeedbackMessage(String message)
		{
			this.content = message;
		}
		
		public FeedbackMessage(String description, Exception ex)
		{
			var buffer = new StringBuilder();
			
			buffer.Append(description);
			buffer.Append(System.Environment.NewLine);
			buffer.Append(ex.Message);
			buffer.Append(System.Environment.NewLine);
			buffer.Append(ex.StackTrace);
			
			this.content = buffer.ToString();
		}
		
		public override string ToString()
		{
			return this.content;
		}
	}
}
