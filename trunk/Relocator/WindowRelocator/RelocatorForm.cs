using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FoundationClassLibrary.Data;
using RelocatorClassLibrary;

namespace WindowRelocator
{
	public partial class RelocatorForm : Form
	{

		#region init
		public RelocatorForm()
		{
			InitializeComponent();

			RefreshForm();
		}
		#endregion

		#region event handlers
		private void radButtonRelocate_Click(object sender, EventArgs e)
		{
			WindowInstance selectedWindow = (WindowInstance)radDropDownListWindow.SelectedItem.Value;
			Screen selectedScreen = (Screen)radDropDownListScreen.SelectedItem.Value;
			int x = StringFormatter.ToInt(radTextBoxX.Text, 0);
			int y = StringFormatter.ToInt(radTextBoxY.Text, 0);
			Relocator.Relocate(selectedWindow.handerId, selectedScreen, x, y, radCheckBoxRemoveTitle.Checked);
		}

		private void radButtonRefresh_Click(object sender, EventArgs e)
		{
			RefreshForm();
		}
		#endregion

		#region private methods

		private void RefreshForm()
		{
			List<WindowInstance> windows = Relocator.FindWindows();
			radDropDownListWindow.DataSource = windows;
			radDropDownListWindow.Rebind();

			radDropDownListScreen.DataSource = Screen.AllScreens;
		}

		#endregion
	}
}
