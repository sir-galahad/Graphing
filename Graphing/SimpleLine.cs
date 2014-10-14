/*
 * Created by SharpDevelop.
 * User: aaron
 * Date: 09/28/2014
 * Time: 21:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
namespace Graphing
{
	/// <summary>
	/// a simple line in slope-intercept form
	/// </summary>
	public class SimpleLine : IGraphLine{
		float Slope;
		float YIntercept;
		float XMin;
		float XMax;
		public Color Color{get;set;}
		public SimpleLine(float slope, float yIntercept,int xMin,int xMax){
			Slope=slope;
			YIntercept=yIntercept;
			XMin=xMin;
			XMax=xMax;
			Color=Color.Black;
		}
		
		public IEnumerable<GraphPoint> GetPoints(){
			yield return new GraphPoint(XMin,Slope*XMin+YIntercept);
			yield return new GraphPoint(XMax,Slope*XMax+YIntercept);
		}
	}
}
