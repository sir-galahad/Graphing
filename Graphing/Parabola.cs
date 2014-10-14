/*
 * Created by SharpDevelop.
 * User: aaron
 * Date: 10/1/2014
 * Time: 11:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
namespace Graphing
{
	/// <summary>
	/// This class is added to a GraphDrawer to show a parabola
	/// </summary>
	public class Parabola:IGraphLine{
		
		public Parabola(){
			Color=Color.Black;
		}
		public Color Color{get;set;}
		public IEnumerable<GraphPoint> GetPoints(){
			for(float x=-100;x<=100;x+=.25F){
				yield return new GraphPoint(x,(float)(Math.Pow(x,2)*.5f));
			}
			
		}
	}
}
