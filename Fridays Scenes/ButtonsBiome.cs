using Godot;
using System;
using NGJ2026.Scripts.Order.Components.Biome;

public partial class ButtonsBiome : PanelContainer
{
	public Action<int> chooseWorld;
	
	public void createWorld(int i)
	{
		GD.Print("Invoking world " + i);
		chooseWorld?.Invoke(i);
	}
}
