/*
 * Date: 6/20/2013
 * Time: 11:27 PM
 */
namespace Xel.UI
{
	partial class FeedbackForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.feedbackText = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// feedbackText
			// 
			this.feedbackText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.feedbackText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.feedbackText.Location = new System.Drawing.Point(0, 0);
			this.feedbackText.Multiline = true;
			this.feedbackText.Name = "feedbackText";
			this.feedbackText.ReadOnly = true;
			this.feedbackText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.feedbackText.Size = new System.Drawing.Size(284, 262);
			this.feedbackText.TabIndex = 0;
			this.feedbackText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FeedbackTextKeyUp);
			this.feedbackText.Leave += new System.EventHandler(this.FeedbackTextLeave);
			// 
			// FeedbackForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.ControlBox = false;
			this.Controls.Add(this.feedbackText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FeedbackForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Error";
			this.TopMost = true;
			this.Deactivate += new System.EventHandler(this.FeedbackFormDeactivate);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FeedbackFormKeyUp);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox feedbackText;
	}
}
