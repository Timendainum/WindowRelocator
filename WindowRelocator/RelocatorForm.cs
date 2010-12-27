using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RelocatorClassLibrary;
using Telerik.WinControls.UI;
using FoundationClassLibrary.Data;

namespace WindowRelocator
{
	public partial class RelocatorForm : Form
	{
		public RelocatorForm()
		{
			InitializeComponent();

			List<WindowInstance> windows = Relocator.FindWindows();
			windowDropDownList.DataSource = windows;
			windowDropDownList.Rebind();

			screenDropDownList.DataSource = Screen.AllScreens;
		}

		private void RelocatorForm_Activated(object sender, EventArgs e)
		{
			
		}

		private void relocateButton_Click(object sender, EventArgs e)
		{
			WindowInstance selectedWindow = (WindowInstance)windowDropDownList.SelectedItem.Value;
			Screen selectedScreen = (Screen)screenDropDownList.SelectedItem.Value;
			int x = StringFormatter.ToInt(radTextBoxX.Text, 0);
			int y = StringFormatter.ToInt(radTextBoxY.Text, 0);
			Relocator.Relocate(selectedWindow.handerId, selectedScreen, x, y);
		}
	}
}
