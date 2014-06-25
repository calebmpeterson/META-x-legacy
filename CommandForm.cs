/*
 * Date: 12/24/2012
 * Time: 3:46 AM
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ShellLib;

namespace MetaX.UI
{	
	/// <summary>
	/// Form for entering commands.
	/// </summary>
	public partial class CommandForm : ShellLib.ApplicationDesktopToolbar
	{
		#region Private Members
		
		private readonly IController controller;
		
		private Config config = new Config();
		
		private IntPtr previousForegroundWindow;
		
		#endregion
		
		public CommandForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			this.Edge = AppBarEdges.Bottom;
			
			this.Owner = CreateHelper();
			
			bool registered = RegisterHotKey(Handle, 1, MOD_CONTROL | MOD_ALT | MOD_NOREPEAT, (int) ' ');
			
			SendMessage(command.Handle, EM_SETCUEBANNER, 0, "META-x : M-x for the whole OS... <Ctrl+Alt+Space>");
			
			//this.command.BackColor = config.BackColor;
			//this.command.ForeColor = config.ForeColor;
			//this.BackColor = config.BackColor;
			
			//this.controller = new HttpController(this.config, this.command);
			this.controller = new EmbeddedController(this, this.command);
			
			RefreshCommands();
		}
		
		private Form CreateHelper()
		{
			Form form = new Form(); // Create helper window
			form.Top = -100; // Location of new window is outside of visible part of screen
			form.Left = -100;
			form.Width = 1; // size of window is enough small to avoid its appearance at the beginning
			form.Height = 1;
			form.FormBorderStyle = FormBorderStyle.FixedToolWindow; // Set window style as ToolWindow to avoid its icon in AltTab
			form.ShowInTaskbar = false;
			form.Show(); // We need to show window before set is as owner to our main window
			form.Hide(); // Hide helper window just in case
			return form;
		}
		
		#region Command Refresh
		
		private void RefreshCommands()
		{
			Trace.TraceInformation("REFRESHING...");
			Trace.Indent();
			
			var currentCommand = this.command.Text;
			this.command.Enabled = false;
			this.command.Text = "Reloading...";
			
			// TODO Do this on another thread?
			this.controller.RefreshCommands();
			
			this.command.Text = currentCommand;
			this.command.Enabled = true;
			this.command.SelectAll();
			this.command.Focus();
				
			Trace.Unindent();
			Trace.TraceInformation("REFRESHED");
		}
		
		#endregion
		
		#region Key Handlers
		
		void CommandFormDeactivate(object sender, EventArgs e)
		{
			Trace.TraceInformation("DEACTIVATED");
		} 
		
		void CommandFormActivated(object sender, EventArgs e)
		{
			Trace.TraceInformation("ACTIVATED");
		}
		
		void CommandKeyUp(object sender, KeyEventArgs e)
		{
			// Enter or Escape => Surrender Focus
			// Ctrl+Enter => Don't Surrender Focus
			if (!e.Control && e.KeyCode == Keys.Return || e.KeyCode == Keys.Escape)
			{
				if (previousForegroundWindow != null)
				{
					SetForegroundWindow(previousForegroundWindow);
				}
				else
				{
					Trace.TraceWarning("no previous foreground window");
				}
			}
			
			if (e.KeyCode == Keys.Return)
			{
				var command = this.command.Text;
				Trace.TraceInformation("EXECUTING: " + command);
				Trace.Indent();
				
				this.controller.ExecuteCommand(command);
				
				Trace.Unindent();
				Trace.TraceInformation("EXECUTED");
			}
			
			if (e.KeyCode == Keys.F5)
			{				
				RefreshCommands();
			}
		}
		
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == WM_HOTKEY)
			{
				previousForegroundWindow = GetForegroundWindow();
				
				SetForegroundWindow(this.Handle);
				BringToFront();
				Focus();
			}
			
			if (m.Msg == WM_ACTIVATE)
			{
				// previousForegroundWindow = m.LParam;
			}
			
			if (m.Msg == WM_HOTKEY || m.Msg == WM_ACTIVATE)
			{
				this.command.Focus();
				this.command.SelectAll();
			}
			
			base.WndProc(ref m);
		}
		
		#endregion
		
		#region Interop
		
		public const int MOD_ALT = 0x0001;
		public const int MOD_CONTROL = 0x0002;
		public const int MOD_SHIFT = 0x0004;
		public const int MOD_WIN = 0x0008;
		public const int MOD_NOREPEAT = 0x4000;
		
		public const int WM_ACTIVATE = 0x6;
		public const int WM_HOTKEY = 0x312;
		
		[DllImport("user32.dll")]
		private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

		private const int EM_SETCUEBANNER = 0x1501;
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
		
		[DllImport("user32.dll")]
		public static extern IntPtr GetForegroundWindow();
		
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool SetForegroundWindow(IntPtr hWnd);
		
		#endregion
	}
}
