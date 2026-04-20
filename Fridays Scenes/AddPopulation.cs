using Godot;
using NGJ2026.Scripts;
using NGJ2026.Scripts.Order.Components.Biome;
using NGJ2026.Scripts.Order.Components.Population;

namespace NGJ2026.Fridays_Scenes;

public partial class AddPopulation : Node2D
{
	private Biome biome;
	[Export] PackedScene biomeScene;
	[Export] private Node2D biomeSpot;
	public override void _Ready()
	{
		if (PlanetBuilder.Instance.Biome != null)
		{
			GD.Print(PlanetBuilder.Instance.Biome.Name);
			biome = (Biome)PlanetBuilder.Instance.Biome.Duplicate();
		}
		else
		{
			GD.Print("Biome not found");
			biome = ResourceLoader.Load<PackedScene>(biomeScene.ResourcePath).Instantiate<Biome>();
		}
		biome.Position = PlanetBuilder.Instance.BiomeSpot;
		AddChild(biome);
		
	}

	public void onNextLevel()
	{
		var children = GetChildren(true);
		foreach (var child in children)
		{
			if (child.GetType() != typeof(Population))
			{
				children.Remove(child);
			}
		}
		PlanetBuilder.Instance.populationMembers = children;
		GameManager.Instance.setScene(4);
	}
	
}