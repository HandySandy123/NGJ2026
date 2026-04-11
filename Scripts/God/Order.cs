using Godot;
using System;

public partial class Order : Node2D
{
	[Export] private float SlimeDustRatio;
	[Export] private string[] order;

	public string getLine(int index)
	{
		if(index < order.Length)
		{
			return order[index];
		}
		else
		{
			return "";
		}
	}

	public int GetOrderLength()
	{
		return order.Length;
	}
}
