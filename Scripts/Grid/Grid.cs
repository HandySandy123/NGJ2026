using Godot;
using NGJ2026.Scripts.Order.Components.Population;

namespace NGJ2026.Scripts.Grid;

public partial class Grid : Node2D
{
	[Export] public int width = 400;
	[Export] public int height = 280;

	private Population[][] GridArr;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Initialize(width, height);
	}

	private void Initialize(int width, int height)
	{
		GridArr = new Population[width][];
		for (int i = 0; i < GridArr.Length; i++)
		{
			GridArr[i] = new Population[height];
		}
	}

	public void clear()
	{
		GridArr = new Population[width][];
		for (int i = 0; i < GridArr.Length; i++)
		{
			GridArr[i] = new Population[height];
		}
	}

	public void set(int x, int y, Population population)
	{
		GridArr[x][y] = population;
	}

	public void Swap(int a, int b)
	{
		(GridArr[a], GridArr[b]) = (GridArr[b], GridArr[a]);
	}

	public bool isEmpty(int index)
	{
		return GridArr[index] == null;
	}
}