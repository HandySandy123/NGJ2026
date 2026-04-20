using Godot;
using NGJ2026.Fridays_Scenes;
using NGJ2026.Scripts;
using NGJ2026.Scripts.Order.Components.Biome;

namespace NGJ2026.Levels.SP_Levels.ChooseBiome;

public partial class ChooseBiome : Node2D
{
	[Export] private Node2D biomeSpot;
	[Export] private PackedScene[] biomes;
	private StringName[] biomePaths;
	private Node2D _activeBiome;
	[Export] private OrbArrow _orbArrow;

	public override void _Ready()
	{
		PlanetBuilder.Instance.BiomeSpot = biomeSpot.Position;
		biomePaths = new StringName[biomes.Length];
		for (int i = 0; i < biomes.Length; i++)
		{
			biomePaths[i] = biomes[i].ResourcePath;
			GD.Print("Biome Path: " + biomes[i].ResourcePath);
		}
	}

	public void setBiome(int index)
	{
		if (_activeBiome != null)
		{
			_activeBiome.Visible = false;
		}
		_orbArrow.setArrow(true);
		_activeBiome =(Node2D)GD.Load<PackedScene>(biomePaths[index]).Instantiate();
		AddChild(_activeBiome);
		_activeBiome.Position = biomeSpot.Position;
		_activeBiome.Visible = true;
		if (_activeBiome is Biome biome)
		{
			PlanetBuilder.Instance.Biome = biome;
		}
	}
	
}