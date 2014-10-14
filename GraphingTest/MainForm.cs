/*
 * Created by SharpDevelop.
 * User: aaron
 * Date: 10/14/2014
 * Time: 5:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Graphing;
namespace GraphingTest
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form{
		public MainForm(){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			IGraphLine line1=new Parabola();
			IGraphLine line2=new SimpleLine(1,0,-10,10);
			line1.Color=Color.Red;
			line2.Color=Color.Blue;
			graphWidget.GraphLines.Add(line1);
			graphWidget.GraphLines.Add(line2);
			graphWidget.GridMode= GridMode.YAxis|GridMode.XAxis;
			graphWidget.XAxisLabel="Time";
			graphWidget.YAxisLabel="Amount of stuff that happens";
		}
	}
}
