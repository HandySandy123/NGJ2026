using Godot;
using System;
using System.Collections.Generic;
using Godot.Collections;
using NGJ2026.Scripts.Order.Components.Biome;
using NGJ2026.Scripts.Order.Components.Population;

public partial class PlanetBuilder : Node2D
{
	public static PlanetBuilder Instance { get; private set; }
	private Biome _biome;
	[Export] PackedScene placeHolderBiome;
	[Export] public Vector2 BiomeSpot;
	private List<GeographicalFeatures> _geographicalFeatures = new List<GeographicalFeatures>();
	private List<Population> _population = new List<Population>();
	public Array<Node> populationMembers;

	public Biome Biome
	{
		get => _biome;
		set
		{
			_biome = value;
			GD.Print("Biome: " + _biome.Name);
		}
	}

	public override void _EnterTree()
	{
		Instance = this;
		// _biome = ResourceLoader.Load<PackedScene>(placeHolderBiome.ResourcePath).Instantiate<Biome>();
		// AddChild(_biome);
		// _biome.Position = BiomeSpot;
		
	}

	public List<GeographicalFeatures> GeographicalFeatures
	{
		get => _geographicalFeatures; 
	}

	public void addGeographicalFeature(GeographicalFeatures geographicalFeatures)
	{
		_geographicalFeatures.Add(geographicalFeatures);
	}

	public List<Population> Population
	{
		get => _population;
		
	}

	public void addToPopulation(Population population)
	{
		foreach (var pop in _population)
		{
			if (pop.GetType() == population.GetType()) return;
		}
		_population.Add(population);
	}

	public void addPopulation(Population population)
	{
		_population.Add(population);
	}
}
