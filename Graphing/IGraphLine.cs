/*
 * Created by SharpDevelop.
 * User: aaron
 * Date: 09/28/2014
 * Time: 20:35
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
	/// the interface that defines a line to be drawn on a graph
	/// </summary>
	public interface IGraphLine{
		Color Color{get;set;}
		IEnumerable<GraphPoint> GetPoints();
		
	}
}
