namespace WindowRelocator
{
	partial class RelocatorForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.relocateButton = new Telerik.WinControls.UI.RadButton();
			this.windowDropDownList = new Telerik.WinControls.UI.RadDropDownList();
			this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
			this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
			this.screenDropDownList = new Telerik.WinControls.UI.RadDropDownList();
			this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
			this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
			this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
			this.radTextBoxX = new Telerik.WinControls.UI.RadTextBox();
			this.radTextBoxY = new Telerik.WinControls.UI.RadTextBox();
			((System.ComponentModel.ISupportInitialize)(this.relocateButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.windowDropDownList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.screenDropDownList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radTextBoxX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radTextBoxY)).BeginInit();
			this.SuspendLayout();
			// 
			// relocateButton
			// 
			this.relocateButton.Location = new System.Drawing.Point(12, 90);
			this.relocateButton.Name = "relocateButton";
			this.relocateButton.Size = new System.Drawing.Size(430, 70);
			this.relocateButton.TabIndex = 0;
			this.relocateButton.Text = "Relocate";
			this.relocateButton.Click += new System.EventHandler(this.relocateButton_Click);
			// 
			// windowDropDownList
			// 
			this.windowDropDownList.Location = new System.Drawing.Point(75, 12);
			this.windowDropDownList.Name = "windowDropDownList";
			this.windowDropDownList.Size = new System.Drawing.Size(367, 20);
			this.windowDropDownList.TabIndex = 1;
			this.windowDropDownList.Text = "none";
			// 
			// radLabel1
			// 
			this.radLabel1.Location = new System.Drawing.Point(19, 15);
			this.radLabel1.Name = "radLabel1";
			this.radLabel1.Size = new System.Drawing.Size(50, 16);
			this.radLabel1.TabIndex = 2;
			this.radLabel1.Text = "Window:";
			// 
			// radLabel2
			// 
			this.radLabel2.Location = new System.Drawing.Point(24, 41);
			this.radLabel2.Name = "radLabel2";
			this.radLabel2.Size = new System.Drawing.Size(45, 16);
			this.radLabel2.TabIndex = 3;
			this.radLabel2.Text = "Screen:";
			// 
			// screenDropDownList
			// 
			this.screenDropDownList.Location = new System.Drawing.Point(75, 38);
			this.screenDropDownList.Name = "screenDropDownList";
			this.screenDropDownList.Size = new System.Drawing.Size(367, 20);
			this.screenDropDownList.TabIndex = 4;
			this.screenDropDownList.Text = "none";
			// 
			// radLabel3
			// 
			this.radLabel3.Location = new System.Drawing.Point(24, 65);
			this.radLabel3.Name = "radLabel3";
			this.radLabel3.Size = new System.Drawing.Size(40, 16);
			this.radLabel3.TabIndex = 5;
			this.radLabel3.Text = "Offset:";
			// 
			// radLabel4
			// 
			this.radLabel4.Location = new System.Drawing.Point(75, 65);
			this.radLabel4.Name = "radLabel4";
			this.radLabel4.Size = new System.Drawing.Size(17, 16);
			this.radLabel4.TabIndex = 6;
			this.radLabel4.Text = "X:";
			// 
			// radLabel5
			// 
			this.radLabel5.Location = new System.Drawing.Point(204, 65);
			this.radLabel5.Name = "radLabel5";
			this.radLabel5.Size = new System.Drawing.Size(17, 16);
			this.radLabel5.TabIndex = 7;
			this.radLabel5.Text = "Y:";
			// 
			// radTextBoxX
			// 
			this.radTextBoxX.Location = new System.Drawing.Point(98, 64);
			this.radTextBoxX.Name = "radTextBoxX";
			this.radTextBoxX.Size = new System.Drawing.Size(100, 20);
			this.radTextBoxX.TabIndex = 8;
			this.radTextBoxX.TabStop = false;
			this.radTextBoxX.Text = "0";
			// 
			// radTextBoxY
			// 
			this.radTextBoxY.Location = new System.Drawing.Point(227, 64);
			this.radTextBoxY.Name = "radTextBoxY";
			this.radTextBoxY.Size = new System.Drawing.Size(100, 20);
			this.radTextBoxY.TabIndex = 9;
			this.radTextBoxY.TabStop = false;
			this.radTextBoxY.Text = "0";
			// 
			// RelocatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(454, 170);
			this.Controls.Add(this.radTextBoxY);
			this.Controls.Add(this.radTextBoxX);
			this.Controls.Add(this.radLabel5);
			this.Controls.Add(this.radLabel4);
			this.Controls.Add(this.radLabel3);
			this.Controls.Add(this.screenDropDownList);
			this.Controls.Add(this.radLabel2);
			this.Controls.Add(this.radLabel1);
			this.Controls.Add(this.windowDropDownList);
			this.Controls.Add(this.relocateButton);
			this.MaximumSize = new System.Drawing.Size(470, 300);
			this.MinimumSize = new System.Drawing.Size(470, 208);
			this.Name = "RelocatorForm";
			this.Text = "Window Relocator";
			this.Activated += new System.EventHandler(this.RelocatorForm_Activated);
			((System.ComponentModel.ISupportInitialize)(this.relocateButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.windowDropDownList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.screenDropDownList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radTextBoxX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radTextBoxY)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Telerik.WinControls.UI.RadButton relocateButton;
		private Telerik.WinControls.UI.RadDropDownList windowDropDownList;
		private Telerik.WinControls.UI.RadLabel radLabel1;
		private Telerik.WinControls.UI.RadLabel radLabel2;
		private Telerik.WinControls.UI.RadDropDownList screenDropDownList;
		private Telerik.WinControls.UI.RadLabel radLabel3;
		private Telerik.WinControls.UI.RadLabel radLabel4;
		private Telerik.WinControls.UI.RadLabel radLabel5;
		private Telerik.WinControls.UI.RadTextBox radTextBoxX;
		private Telerik.WinControls.UI.RadTextBox radTextBoxY;
	}
}

