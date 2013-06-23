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
	public partial class ErrorForm : Form
	{
		public ErrorForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		public static ErrorForm Show(Form owner, string description, Exception ex)
		{
			var form = new ErrorForm();
			var fontHeight = form.errorText.Font.Height;
			
			form.errorText.AppendText(description);
			form.errorText.AppendText(System.Environment.NewLine);
			form.errorText.AppendText(ex.Message);
			form.errorText.AppendText(System.Environment.NewLine);
			form.errorText.AppendText(ex.StackTrace);
			
			form.Owner = owner;
			form.Left = owner.Left + 3;
			form.Width = owner.Width - 6;
			form.Height = Math.Min(
					fontHeight * 15, 
					TextRenderer.MeasureText(form.errorText.Text, form.errorText.Font).Height + fontHeight);
			form.Top = owner.Top - 3 - form.Height;
			
			form.Show();
			form.BringToFront();
			form.Focus();
			form.errorText.Focus();
			
			return form;
		}
		
		void ErrorFormKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
		
		void ErrorTextKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
		
		void ErrorFormDeactivate(object sender, EventArgs e)
		{
			Close();
		}
		
		void ErrorTextLeave(object sender, EventArgs e)
		{
			Close();
		}
	}
}
