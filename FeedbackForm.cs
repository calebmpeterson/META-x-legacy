/*
 * Date: 6/20/2013
 * Time: 11:27 PM
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Xel.UI
{
	/// <summary>
	/// Description of ErrorForm.
	/// </summary>
	public partial class FeedbackForm : Form
	{
		public FeedbackForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		public static FeedbackForm Show(Form owner, string content)
		{
			var form = new FeedbackForm();
			
			form.feedbackText.AppendText(content);
			
			form.Prepare(owner);
			
			return form;
		}
		
		public static FeedbackForm Show(Form owner, FeedbackMessage message)
		{
			var form = new FeedbackForm();
			
			form.feedbackText.AppendText(message.content);
			
			form.Prepare(owner);
			
			return form;
		}
		
		public static FeedbackForm Show(Form owner, string description, Exception ex)
		{
			var form = new FeedbackForm();
			
			form.feedbackText.AppendText(description);
			form.feedbackText.AppendText(System.Environment.NewLine);
			form.feedbackText.AppendText(ex.Message);
			form.feedbackText.AppendText(System.Environment.NewLine);
			form.feedbackText.AppendText(ex.StackTrace);
			
			form.Prepare(owner);
			
			return form;
		}
		
		void Prepare(Form owner)
		{
			var fontHeight = this.feedbackText.Font.Height;
			this.Owner = owner;
			this.Left = owner.Left + 3;
			this.Width = owner.Width - 6;
			this.Height = Math.Min(
					fontHeight * 15, 
					TextRenderer.MeasureText(this.feedbackText.Text, this.feedbackText.Font).Height + fontHeight);
			this.Top = owner.Top - 3 - this.Height;
			
			this.Show();
			this.BringToFront();
			this.Focus();
			this.feedbackText.Focus();
		}
		
		void FeedbackFormKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
		
		void FeedbackTextKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
		
		void FeedbackFormDeactivate(object sender, EventArgs e)
		{
			Close();
		}
		
		void FeedbackTextLeave(object sender, EventArgs e)
		{
			Close();
		}
	}
}
