using Godot;
using NGJ2026.Scripts.Order.Components.Biome;

namespace NGJ2026.Levels.Fridays_Scenes;

public partial class PhysicsObjects : Node2D
{
		private Biome biome;
		[Export] PackedScene biomeScene;
		[Export] private Node2D biomeSpot;

	// Called when the node enters the scene tree for the first time.
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

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}