Graphing
========

a library to draw graphs in C# 

they primary class in this library is the GraphDrawer class that can draw graphs on a given Graphics instance
this should allow a graph to be drawn on System.Windows.Forms controls, images, and printer pages
the way a graph looks is fairly customizable. lines are drawn on the graph by added objects that implement the 
IGraphLine interface to GraphDrawer.GraphLines.
