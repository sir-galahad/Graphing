/*
 * Created by SharpDevelop.
 * User: aaron
 * Date: 09/28/2014
 * Time: 20:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Graphing
{
	/// <summary>
	/// a very simple point
	/// </summary>
	public class GraphPoint{
		public float X{get;private set;}
		public float Y{get;private set;}
		
		public GraphPoint(float x, float y){
			X=x;
			Y=y;
		}
	}
}
