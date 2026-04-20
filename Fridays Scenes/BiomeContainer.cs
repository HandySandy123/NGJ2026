using Godot;
using System;
using NGJ2026.Scripts.Order.Components.Biome;

public partial class BiomeContainer : Node2D
{
	private static Vector2 containerPosition;
	private Biome biome;

	public override void _Process(double delta)
	{
		containerPosition = GlobalPosition;
	}

	public void setBiome()
	{
		biome = (Biome)GetChild(0);
		GD.Print("set biome" + biome.Name);
	}
}
