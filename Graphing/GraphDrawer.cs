/*
 * Created by SharpDevelop.
 * User: aaron
 * Date: 09/24/2014
 * Time: 20:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
namespace Graphing
{
	/// <summary>
	/// a class that draws a graph on graphics object
	/// </summary>
	
	[FlagsAttribute]public  enum GridMode{
		XAxis=1,
		YAxis=2,
		XHatches=4,
		YHatches=8,
		XLines=16,
		YLines=32,
	}
	public class GraphDrawer{
		int Height;
		int Width;
		Graphics g;//this is set by DrawGraph all methods that rely on this should be called from there
		float YMaxIncrementSize=0;//the size of the largest string to be drawn on the axis used to keep 
								  //Y axis markings right aligned
		float XMaxIncrementSize=0;//lengeth of the XMax as a string used to keep it's marker from being
						    	  //half off the graph
		float XMinLoc,XMaxLoc,YMinLoc,YMaxLoc;
		Pen ForegroundPen;
		Brush ForegroundBrush;
		public int XMin{get;set;}
		public int XMax{get;set;}
		public int YMin{get;set;}
		public int YMax{get;set;}
		public String XAxisLabel{get;set;}
		public String YAxisLabel{get;set;}
		public Font Font{get;set;} 
		public List<IGraphLine> GraphLines{get;private set;}
		public GridMode GridMode{get;set;}
		public Color Foreground{get;set;}
		public Color Background{get;set;}
		public GraphDrawer(){
		
			Font=SystemFonts.DefaultFont;
			GraphLines=new List<IGraphLine>();
			XMin=-10;
			XMax=10;
			YMin=-10;
			YMax=10;
			Foreground=Color.Black;
			Background=Color.White;
		}
		
		public void DrawGraph(Graphics g,int Width, int Height){
			this.g=g;
			this.Width=Width;
			this.Height=Height;
			ForegroundPen=new Pen(Foreground);
			ForegroundBrush=new SolidBrush(Foreground);
			g.SmoothingMode=SmoothingMode.HighQuality;
			g.Clear(Background);
			//start by drawing the graph labels
			
			//draws the YAxisLabel from top to bottom
			/*g.RotateTransform(90);
			g.DrawString(YAxisLabel,Font,new SolidBrush(Color.Black),(Height/2)-GetHalfStringWidth(g,YAxisLabel),
			             0-Font.Height);
			g.ResetTransform();*/
			
			//draws the YAxisLabel from bottom to top
			g.RotateTransform(-90);
			DrawCenterAlignedString(Height/2-Height,0,YAxisLabel);
			
			//draws the XAxisLabel
			g.ResetTransform();
			DrawCenterAlignedString(Width/2,Height-Font.Height,XAxisLabel);
			//draw graph increment labels
			XMaxIncrementSize=g.MeasureString(XMax.ToString(),Font).Width;//do this first so GetXLocation works correctly
			//draw Y axis increment labels
			
			
			int incrementLabels=GetLabelScale(YMax-YMin);
			YMaxIncrementSize=0;
			for(int y=YMin;y<=YMax;y+=incrementLabels){
				float temp=g.MeasureString(y.ToString(),Font).Width;
				if(temp>YMaxIncrementSize)YMaxIncrementSize=temp;
			}
			
			XMinLoc=GetXLocation(XMin);
			XMaxLoc=GetXLocation(XMax);
			YMinLoc=GetYLocation(YMin);
			YMaxLoc=GetYLocation(YMax);
			
			for(int y=YMin;y<=YMax;y+=incrementLabels){
				float yLocation=GetYLocation(y);
				DrawRightAlignedString(YMaxIncrementSize+Font.Height,yLocation-Font.Height/2,y.ToString());
				float lineEnd;
				if(GridMode.HasFlag(GridMode.YHatches)||GridMode.HasFlag(GridMode.YLines)){
					if(GridMode.HasFlag(GridMode.YLines)) lineEnd=XMaxLoc;
					else lineEnd=XMinLoc+Font.Height/2;
					g.DrawLine(ForegroundPen,XMinLoc,yLocation,lineEnd,yLocation);
					   
				}
			}
			//draw X axis increment labels 
			incrementLabels=GetLabelScale(XMax-XMin);
			
			for(int x=XMin;x<=XMax;x+=incrementLabels){
				float xLocation=GetXLocation(x);
				DrawCenterAlignedString(xLocation,Height-Font.Height*2,x.ToString());
				float lineEnd;
				if(GridMode.HasFlag(GridMode.XHatches)||GridMode.HasFlag(GridMode.XLines)){
					if(GridMode.HasFlag(GridMode.XLines)) lineEnd=YMaxLoc;
					else lineEnd=YMinLoc-Font.Height/2;
					g.DrawLine(ForegroundPen,xLocation,YMinLoc,xLocation,lineEnd);
					   
				}
			}
			//draw axises if necessary
			float zero;
			if(GridMode.HasFlag(GridMode.YAxis)){
				zero=GetXLocation(0);
				g.DrawLine(ForegroundPen,zero,GetYLocation(YMin),zero,GetYLocation(YMax));
			}
			if(GridMode.HasFlag(GridMode.XAxis)){
				zero=GetYLocation(0);
				g.DrawLine(ForegroundPen,XMinLoc,zero,XMaxLoc,zero);
			}
			//plot the graphs
			PlotGraphs();
			
		}
		void PlotGraphs(){
			Pen pen;
			g.Clip=new Region(new RectangleF(XMinLoc,YMaxLoc,XMaxLoc-XMinLoc,YMinLoc-YMaxLoc));
			//g.DrawLine(new Pen(Foreground),XMinLoc-20,GetYLocation(0),XMaxLoc+20,GetYLocation(0));
			//g.DrawLine(new Pen(Foreground),GetXLocation(0),YMinLoc+20,GetXLocation(0),YMaxLoc-20);
			foreach(IGraphLine line in GraphLines){
				PointF? current=null;
				PointF? previous=null;
				pen=new Pen(line.Color);
				foreach(GraphPoint p in line.GetPoints()){
					previous=current;
					current=ConvertGraphPoint(p);
					if(previous==null)continue;
					g.DrawLine(pen,(PointF)previous,(PointF)current);
				}
			}
		}
		
		PointF ConvertGraphPoint(GraphPoint p){
			float X=GetXLocation(p.X);
			float Y=GetYLocation(p.Y);
			PointF result=new PointF(X,Y);
			return result;
		}
		
		float GetYLocation(float y){
			float result=(y-YMin)/(YMax-YMin);
			float graphHeight=Height-(Font.Height*2.5F);
			result*=graphHeight;
			result-=Font.Height/2;
			result=graphHeight-result;//flip Y so that higher values are higher on the screen
			return result;
		}
		
		float GetXLocation(float x){
			float result=(x-XMin)/(XMax-XMin);
			float graphWidth=Width-(Font.Height+YMaxIncrementSize);//leave room for YAxis label and increment labels
			graphWidth-=XMaxIncrementSize/2+1;//leaves room at the end of the graph so the XMax label isn't half off
			result*=graphWidth;
			result+=(Font.Height+YMaxIncrementSize);
			return result;
		}
		
		float GetHalfStringWidth(string s){
			return g.MeasureString(s,Font).Width/2;
		}
		
		void DrawCenterAlignedString(float x,float y, string str){
			float halfWidth=(float)(g.MeasureString(str,Font).Width)/2;
			x-=halfWidth;
			x=(float)Math.Floor(x);
			g.DrawString(str,Font,ForegroundBrush,x,y);
		}
		
		void DrawRightAlignedString(float x,float y, string str){
			float Width=g.MeasureString(str,Font).Width;
			x-=Width;
			g.DrawString(str,Font,ForegroundBrush,x,y);
		}
		
		int  GetLabelScale(int range){
			bool scaleDecided=false;
			int[] labelScaleOptions = {1,2,5};
			int multiplier=1;
			while(!scaleDecided){
				foreach(int x in labelScaleOptions){
					if(range/(x*multiplier)<=15){
						return(x*multiplier);
					}
				}
				multiplier=multiplier*10;
			}
			return 1;//this shouldn't be reached, but to avoid a compiler warning we'll throw it in
		}
		
	}
}
