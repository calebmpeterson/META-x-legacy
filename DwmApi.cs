/*
 * Date: 6/25/2013
 * Time: 12:10 AM
 * 
 * From: http://blogs.msdn.com/b/tims/archive/2006/04/18/578637.aspx
 */
using System;
using System.Runtime.InteropServices;

namespace DwmLib
{
	/// <summary>
	/// Description of DwmApi.
	/// </summary>
	public class DwmApi
	{
		
		[StructLayout(LayoutKind.Sequential)]
		public struct MARGINS
		{
		   public int cxLeftWidth; 
		   public int cxRightWidth; 
		   public int cyTopHeight; 
		   public int cyBottomHeight; 
		}
		
		[DllImport("dwmapi.dll")] 
		public static extern int DwmExtendFrameIntoClientArea(
		   IntPtr hWnd,
		   ref MARGINS pMarInset
		);
		
	}
}
