/*
 * Created by SharpDevelop.
 * User: aaron
 * Date: 10/14/2014
 * Time: 5:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace GraphingTest
{
	partial class MainForm
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
			this.graphWidget = new Graphing.GraphWidget();
			this.SuspendLayout();
			// 
			// graphWidget
			// 
			this.graphWidget.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.graphWidget.Background = System.Drawing.Color.Black;
			this.graphWidget.Dock = System.Windows.Forms.DockStyle.Fill;
			this.graphWidget.Foreground = System.Drawing.Color.Lime;
			this.graphWidget.Location = new System.Drawing.Point(0, 0);
			this.graphWidget.Name = "graphWidget";
			this.graphWidget.Size = new System.Drawing.Size(445, 301);
			this.graphWidget.TabIndex = 0;
			this.graphWidget.XAxisLabel = null;
			this.graphWidget.XMax = 10;
			this.graphWidget.XMin = -10;
			this.graphWidget.YAxisLabel = null;
			this.graphWidget.YMax = 10;
			this.graphWidget.YMin = -10;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(445, 301);
			this.Controls.Add(this.graphWidget);
			this.Name = "MainForm";
			this.Text = "GraphingTest";
			this.ResumeLayout(false);
		}
		private Graphing.GraphWidget graphWidget;
	}
}
