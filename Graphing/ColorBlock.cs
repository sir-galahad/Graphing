/*
 * Created by SharpDevelop.
 * User: aaron
 * Date: 10/2/2014
 * Time: 9:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Graphing
{
	/// <summary>
	/// just a simple block that can be painted any color
	/// this is intened to be paired with a label to give meaning 
	/// to seperate lines on graphs that have more than one
	/// </summary>
	public partial class ColorBlock : UserControl{
		public ColorBlock(){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
	}
}
