using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace RelocatorClassLibrary
{
    /// <summary>
    /// Provides window-relocation functionality through calls to User32.
    /// </summary>
    public static class Relocator
    {
        public delegate bool WindowFoundHandler(int hwnd, int lParam);

        private static readonly int m_pid = Application.ProductName.GetHashCode();
		private static readonly List<WindowInstance> m_windows = new List<WindowInstance>();

        #region Dimensions
        /// <summary>
        /// Get the dimensions of the window specified by hWnd.
        /// </summary>
        /// <param name="hWnd">A valid window</param>
        /// <returns>new Rectangle(Left, Top, Width, Height)</returns>
        private static Rectangle GetWindowRect(IntPtr hWnd)
        {
            NativeMethods.RECT r;
            NativeMethods.GetWindowRect(hWnd, out r);
            return new Rectangle(r.Left, r.Top, r.Right - r.Left, r.Bottom - r.Top);
        }

        /// <summary>
        /// Get the screen coordinates relative to the window.
        /// </summary>
        /// <param name="hWnd">A valid window</param>
        /// <returns>new Rectangle(Left, Top, Right, Bottom) relative to the screen</returns>
        private static Rectangle GetClientRectInScreenCoords(IntPtr hWnd)
        {
            NativeMethods.RECT cr;
            NativeMethods.GetClientRect(hWnd, out cr);
            NativeMethods.POINT pt = new NativeMethods.POINT();
            pt.X = 0;
            pt.Y = 0;
            NativeMethods.ClientToScreen(hWnd, ref pt);
            return new Rectangle(pt.X, pt.Y, cr.Right - cr.Left, cr.Bottom - cr.Top);
        }

        #endregion

        #region Private functions
        /// <summary>
        /// Callback function for finding all open EVE instance windows.
        /// </summary>
        /// <param name="hwnd">the window information to be tested - automatically passed by EnumWindows</param>
        private static bool EnumWindowCallBack(int hwnd, int lParam)
        {
            IntPtr windowHandle = (IntPtr)hwnd;
            StringBuilder sbText = new StringBuilder(512);
            StringBuilder sbClass = new StringBuilder(512);
            NativeMethods.GetWindowText(windowHandle, sbText, 512);
            NativeMethods.GetClassName(windowHandle, sbClass, 512);

			int pid = 0;
			NativeMethods.GetWindowThreadProcessId(windowHandle, out pid);
			System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(pid);


			string text = sbText.ToString();
			string className = sbClass.ToString();
			string mainWindowTitle = p.MainWindowTitle;

			//Add all windows
			//Only add good windows
			if (!string.IsNullOrEmpty(mainWindowTitle) && !string.IsNullOrEmpty(text))
			{
				Rectangle cr = GetClientRectInScreenCoords(windowHandle);

				if (cr.Height > 500 && cr.Width > 500)
					m_windows.Add(new WindowInstance(windowHandle, GetWindowDescription(windowHandle)));
			}

			//Only return Eve windows
			/*
            if (sbText.ToString().StartsWith("EVE", StringComparison.CurrentCultureIgnoreCase) && sbClass.ToString() == "triuiScreen")
            {
                int pid = 0;
                NativeMethods.GetWindowThreadProcessId(windowHandle, out pid);
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(pid);
                if (p.ProcessName == "ExeFile")
                {
                    m_foundWindows.Add(windowHandle);
                }
            }
			 */
            
            return true;
        }
        #endregion

        #region Public functions
        /// <summary>
        /// Identifies all open EVE instances.
        /// </summary>
        /// <returns>IntPtr array of EVE instances</returns>
        public static List<WindowInstance> FindWindows()
        {
            lock (m_windows)
            {
				m_windows.Clear();
                NativeMethods.EnumWindows(new WindowFoundHandler(EnumWindowCallBack), m_pid);
				return m_windows;
            }
        }

        /// <summary>
        /// Position the window on the target screen.
        /// </summary>
        /// <param name="hWnd">EVE instance to be moved</param>
        /// <param name="targetScreen">Screen to be moved to</param>
        public static void Relocate(IntPtr hWnd, Screen targetScreen, int x, int y)
        {
            Rectangle ncr = GetWindowRect(hWnd);
            Rectangle cr = GetClientRectInScreenCoords(hWnd);
            int wDiff = ncr.Width - cr.Width;
            int hDiff = ncr.Height - cr.Height;

            // Grab the current window style
            int oldStyle = NativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_STYLE);

            // Turn off dialog frame and border
            int newStyle = oldStyle & ~(NativeMethods.WS_DLGFRAME | NativeMethods.WS_BORDER);
            NativeMethods.SetWindowLong(hWnd, NativeMethods.GWL_STYLE, newStyle);

			NativeMethods.MoveWindow(hWnd, targetScreen.Bounds.X + x,
                       targetScreen.Bounds.Y + y,
                       cr.Width,
                       cr.Height, true);
        }

        /// <summary>
        /// Get's the title bar text and resolution of the specified window.
        /// </summary>
        public static string GetWindowDescription(IntPtr hWnd)
        {
            StringBuilder sb = new StringBuilder(512);

            NativeMethods.GetWindowText(hWnd, sb, 512);
            sb.Append(" - ");

            Rectangle cr = GetClientRectInScreenCoords(hWnd);

            if ((cr.Height == 0) && (cr.Width == 0))
            {
                sb.Append("Minimized");
            }
            else
            {
                sb.AppendFormat("{0}x{1}", cr.Width, cr.Height);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns the resolution of the specified window.
        /// </summary>
        public static Rectangle GetWindowDimensions(IntPtr hWnd)
        {
            return GetClientRectInScreenCoords(hWnd);
        }

        /// <summary>
        /// Returns the number and resolution of the passed screen number.
        /// </summary>
        /// <param name="screen">Integer of the screen to be identified</param>
        /// <returns>Screen z - WidthxHeight</returns>
        public static string GetScreenDescription(int screen)
        {
            Screen sc = Screen.AllScreens[screen];
            return String.Format("Screen {0} - {1}x{2}", screen + 1, sc.Bounds.Width, sc.Bounds.Height);
        }

        #endregion
    }

    #region Native Stuff
    /// <summary>
    /// Provides window-relocation functionality through calls to User32
    /// </summary>
    public static class NativeMethods
    {

        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        public const int GWL_STYLE = -16;
        public const int WS_DLGFRAME = 0x00400000;
        public const int WS_BORDER = 0x00800000;

        [DllImport("user32.Dll")]
        public static extern IntPtr EnumWindows(Relocator.WindowFoundHandler x, int y);

        [DllImport("User32.Dll")]
        public static extern void GetClassName(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("user32")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32")]
        public static extern int GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        
        [DllImport("user32")]
        public static extern int ClientToScreen(IntPtr hWnd, ref POINT lpPoint);

        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    }
    #endregion

}