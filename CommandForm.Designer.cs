/*
 * Date: 12/24/2012
 * Time: 3:46 AM
 */
namespace Xel.UI
{
	partial class CommandForm
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
			if (disposing)
			{
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
			this.command = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// command
			// 
			this.command.AcceptsReturn = true;
			this.command.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.command.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.command.Dock = System.Windows.Forms.DockStyle.Fill;
			this.command.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.command.Location = new System.Drawing.Point(2, 2);
			this.command.Margin = new System.Windows.Forms.Padding(2);
			this.command.Name = "command";
			this.command.Size = new System.Drawing.Size(281, 22);
			this.command.TabIndex = 0;
			this.command.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CommandKeyUp);
			// 
			// CommandForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(285, 27);
			this.ControlBox = false;
			this.Controls.Add(this.command);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "CommandForm";
			this.Padding = new System.Windows.Forms.Padding(2, 2, 2, 4);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			this.Activated += new System.EventHandler(this.CommandFormActivated);
			this.Deactivate += new System.EventHandler(this.CommandFormDeactivate);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox command;
	}
}
