/*
 * Created by SharpDevelop.
 * User: aaron
 * Date: 09/23/2014
 * Time: 20:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Graphing 
{
	/// <summary>
	/// Description of Graph.
	/// </summary>
	public partial class GraphWidget : UserControl
	{
		GraphDrawer drawer;
		public int XMax{get{return drawer.XMax;}set{drawer.XMax=value;}}
		public int YMax{get{return drawer.YMax;}set{drawer.YMax=value;}}
		public int XMin{get{return drawer.XMin;}set{drawer.XMin=value;}}
		public int YMin{get{return drawer.YMin;}set{drawer.YMin=value;}}
		public Color Foreground{get{return drawer.Foreground;}set{drawer.Foreground=value;}}
		public Color Background{get{return drawer.Background;}set{drawer.Background=value;}}
		public string XAxisLabel{get{return drawer.XAxisLabel;}set{drawer.XAxisLabel=value;}}
		public string YAxisLabel{get{return drawer.YAxisLabel;}set{drawer.YAxisLabel=value;}}
		public List<IGraphLine> GraphLines{get{return drawer.GraphLines;}private set{}}
		public GridMode GridMode{get{return drawer.GridMode;}set{drawer.GridMode=value;}}
		public GraphWidget(){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			drawer=new GraphDrawer();
			
			//drawer.GraphLines.Add(new Parabola());
		}
		
		protected override void OnPaint(PaintEventArgs pe){
			Graphics g=this.CreateGraphics();
			
			//drawer.Font=new Font("Consolas",8);
			
			drawer.DrawGraph(g,Width,Height);	
		}
	
	}
}
